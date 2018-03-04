using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsInputRecorder.Forms;
using WindowsInputRecorder.Hooks;
using WindowsInputRecorder.Inputs;
using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Sessions
{
    public class Session : IDisposable
    {
        private static uint periodMax;
        private static uint periodMin;

        private PacketList packets;
        private MouseHook mouse;
        private MouseHookSlim mouseSlim;
        private KeyboardHook keyboard;
        private KeyboardHookSlim keyboardSlim;
        private KeyCharHook keyChar;
        private Stopwatch stopwatch;
        private ManualResetEvent manualResetEvent;
        private Thread thread;
        private SendInput sendInput;
        private SessionState state;
        private Keys[] excludedKeys;
        private long lastWaitTime;
        private long minWaitTime;
        private bool recordMouse;
        private bool recordMouseUp;
        private bool recordKeyboard;
        private bool recordKeyboardUp;
        private bool recordKeyChar;
        private bool mergeKeyChar;
        private bool excludeKeys;

        private double speed;
        private int times;

        static Session()
        {
            TimeCaps timeCaps = new TimeCaps();
            NativeMethods.timeGetDevCaps(ref timeCaps, (uint)Marshal.SizeOf(timeCaps));
            periodMax = timeCaps.wPeriodMax;
            periodMin = timeCaps.wPeriodMin;
        }

        public Session()
        {
            this.packets = new PacketList();
            this.mouse = new MouseHook();
            this.mouseSlim = new MouseHookSlim();
            this.keyboard = new KeyboardHook();
            this.keyboardSlim = new KeyboardHookSlim();
            this.keyChar = new KeyCharHook();
            this.stopwatch = new Stopwatch();
            this.minWaitTime = 1;
            this.recordMouse = true;
            this.recordMouseUp = true;
            this.recordKeyboard = true;
            this.recordKeyboardUp = true;
            this.recordKeyChar = false;
            this.mergeKeyChar = false;
            this.excludeKeys = false;
            this.excludedKeys = new Keys[0];
            this.manualResetEvent = new ManualResetEvent(false);
            this.sendInput = new SendInput();
            this.speed = 1.0;
            this.times = 1;
            this.minWaitTime = 1;

            mouse.InputEvent += system_event;
            mouseSlim.InputEvent += system_event;
            keyboard.InputEvent += system_event;
            keyboardSlim.InputEvent += system_event;
            keyChar.InputEvent += system_event;
            state = SessionState.Idle;
        }

        ~Session()
        {
            Dispose(false);
        }

        public event EventHandler StateChanged;
        public event PacketHandler PacketRecorded;

        public PacketList Packets
        {
            get { return packets; }
        }

        public SessionState State
        {
            get { return state; }
            private set
            {
                if (state == value)
                    return;

                state = value;

                if (StateChanged != null)
                    StateChanged(this, EventArgs.Empty);
            }
        }

        public bool Busy
        {
            get { return state != SessionState.Idle; }
        }

        public long MinWaitTime
        {
            get { return minWaitTime; }
            set { minWaitTime = value; }
        }

        public bool RecordMouse
        {
            get { return recordMouse; }
            set { recordMouse = value; }
        }

        public bool RecordMouseUp
        {
            get { return recordMouseUp; }
            set { recordMouseUp = value; }
        }

        public bool RecordMouseMove
        {
            get { return mouse.EnableMouseMove; }
            set { mouse.EnableMouseMove = value; }
        }

        public bool RecordKeyboard
        {
            get { return recordKeyboard; }
            set { recordKeyboard = value; }
        }

        public bool RecordKeyboardUp
        {
            get { return recordKeyboardUp; }
            set { recordKeyboardUp = value; }
        }

        public bool RecordKeyChar
        {
            get { return recordKeyChar; }
            set { recordKeyChar = value; }
        }

        public bool MergeKeyChar
        {
            get { return mergeKeyChar; }
            set { mergeKeyChar = value; }
        }

        public bool ExcludeKeys
        {
            get { return excludeKeys; }
            set { excludeKeys = value; }
        }

        public Keys[] ExcludedKeys
        {
            get { return excludedKeys; }
            set { excludedKeys = value; }
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Times
        {
            get { return times; }
            set { times = value; }
        }

        public void Stop()
        {
            if (state == SessionState.Recording)
            {
                if (recordMouse)
                    if (recordMouseUp)
                        mouse.Stop();
                    else
                        mouseSlim.Stop();

                if (recordKeyboard)
                {
                    if (!recordKeyChar)
                        if (recordKeyboardUp)
                            keyboard.Stop();
                        else
                            keyboardSlim.Stop();
                    else
                        keyChar.Stop();
                }

                stopwatch.Reset();

                if (mergeKeyChar)
                    MergeKeyChars(packets);

                State = SessionState.Idle;
            }
            else if (state == SessionState.Playing)
            {
                state = SessionState.IdlePending;
                manualResetEvent.Set();
                thread.Join();
            }
        }
        
        public void Play()
        {
            if (Busy)
                return;

            State = SessionState.Playing;

            thread = new Thread(PlaySync);
            thread.Name = "Play Thread";
            thread.Start();
        }

        public void Record()
        {
            if (Busy)
                return;

            lastWaitTime = 0;
            stopwatch.Start();

            if (recordMouse)
                if (recordMouseUp)
                    mouse.Start();
                else
                    mouseSlim.Start();

            if (recordKeyboard)
            {
                if (!recordKeyChar)
                    if (recordKeyboardUp)
                        keyboard.Start();
                    else
                        keyboardSlim.Start();
                else
                    keyChar.Start();
            }

            State = SessionState.Recording;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Stop();

            if (disposing)
            {
                mouse.Dispose();
                mouseSlim.Dispose();
                keyboard.Dispose();
                keyboardSlim.Dispose();
                keyChar.Dispose();
                manualResetEvent.Close();
            }
        }

        private static void MergeKeyChars(PacketList packets)
        {
            List<KeyCharPacket> keyCharPackets = new List<KeyCharPacket>();
            StringBuilder sb = new StringBuilder();
            int curPos = 0;
            int lastPos;
            int postWaitTime = 0;

            for (lastPos = 0; lastPos < packets.Count; lastPos++)
            {
                KeyCharPacket p = packets[lastPos] as KeyCharPacket;

                if (p == null)
                    continue;

                keyCharPackets.Add(p);

                for (curPos = lastPos + 1; curPos < packets.Count; curPos++)
                {
                    WaitPacket w = packets[curPos] as WaitPacket;

                    if (w != null)
                    {
                        postWaitTime += w.Milliseconds;
                        continue;
                    }

                    KeyCharPacket k = packets[curPos] as KeyCharPacket;

                    if (k == null)
                        break;

                    keyCharPackets.Add(k);
                }

                if (keyCharPackets.Count > 1)
                {
                    sb.Length = 0;
                    for (int j = 0; j < keyCharPackets.Count; j++)
                        sb.Append(((KeyCharInput)keyCharPackets[j].Input).Character);

                    packets.RemoveRange(lastPos, curPos - lastPos);
                    packets.Insert(lastPos, new SendTextInput(sb.ToString()).ToPacket());

                    if (postWaitTime > 0)
                        packets.Insert(lastPos + 1, new WaitPacket(postWaitTime));
                }

                keyCharPackets.Clear();
                postWaitTime = 0;
            }

            if (keyCharPackets.Count > 1)
            {
                sb.Length = 0;
                for (int j = 0; j < keyCharPackets.Count; j++)
                    sb.Append(((KeyCharInput)keyCharPackets[j].Input).Character);

                packets.RemoveRange(lastPos, curPos - lastPos);
                packets.Insert(lastPos, new SendTextInput(sb.ToString()).ToPacket());

                if (postWaitTime > 0)
                    packets.Insert(lastPos + 1, new WaitPacket(postWaitTime));
            }
        }

        private void system_event(Input input)
        {
            if (excludeKeys)
            {
                KeyboardInput k = input as KeyboardInput;

                if (k != null)
                    for (int i = 0; i < excludedKeys.Length; i++)
                        if (k.Key == excludedKeys[i])
                            return;
            }

            system_wait();
            AddPacket(input.ToPacket());
        }

        private void system_wait()
        {
            long currentWaitTime = stopwatch.ElapsedMilliseconds;
            long delay = currentWaitTime - lastWaitTime;

            if (delay < minWaitTime || delay > int.MaxValue)
                return;

            AddPacket(new WaitPacket((int)delay));

            lastWaitTime = currentWaitTime;
        }

        private void AddPacket(Packet packet)
        {
            packets.Add(packet);

            if (PacketRecorded != null)
                PacketRecorded(packet);
        }

        private void PlaySync()
        {
            try
            {
                manualResetEvent.Reset();
                MouseInput.GetMaxSize();

                uint period = Math.Max(periodMin, Math.Min(periodMax, (uint)GetWaitTime((int)minWaitTime))); ;

                if (NativeMethods.timeBeginPeriod(period) != 0)
                    throw new Exception("timeBeginPeriod failed.");

                for (int i = 0; i < times && State == SessionState.Playing; i++)
                    for (int j = 0; j < packets.Count && State == SessionState.Playing; j++)
                    {
                        Packet packet = packets[j];

                        WaitPacket wait = packet as WaitPacket;

                        if (wait != null)
                        {
                            sendInput.Flush();
                            int waitTime = GetWaitTime(wait.Milliseconds);

                            if (waitTime > 0)
                                manualResetEvent.WaitOne(waitTime);

                            continue;
                        }

                        InputPacket input = packet as InputPacket;

                        if (input != null)
                        {
                            sendInput.Queue(input.Input);
                            continue;
                        }
                    }

                if (State == SessionState.Playing)
                    sendInput.Flush();

                if (NativeMethods.timeEndPeriod(period) != 0)
                    throw new Exception("timeEndPeriod failed.");
            }
            catch (Exception ex)
            {
                MainForm.ShowError(ex);
            }

            State = SessionState.Idle;
        }

        private int GetWaitTime(int value)
        {
            return (int)Math.Max(0, Math.Min(int.MaxValue, Math.Round(value / speed)));
        }
    }
}
