using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowsInputRecorder.Sessions;

namespace WindowsInputRecorder.Settings
{
    public class Options : IDisposable
    {
        public const int KEY_COUNT = 3;

        public static string defaultFileName = "settings.dat";

        public bool recordMouse;
        public bool recordMouseUp;
        public bool recordMouseMove;
        public bool recordKeyboard;
        public bool recordKeyboardUp;
        public bool recordKeyChar;
        public bool mergeKeyChar;
        public bool recordWait;
        public int minWaitTime;
        public Hotkeys hotkeys;
        public bool clearOnRecord;
        public bool toggleHotkeys;
        public bool filterHotkeys;

        public Options(IntPtr windowHandle)
        {
            hotkeys = new Hotkeys(windowHandle, KEY_COUNT);
            LoadDefaults();
        }

        ~Options()
        {
            Dispose(true);
        }

        public void ApplyTo(Session session)
        {
            session.RecordMouse = recordMouse;
            session.RecordMouseUp = recordMouseUp;
            session.RecordMouseMove = recordMouseMove;
            session.RecordKeyboard = recordKeyboard;
            session.RecordKeyboardUp = recordKeyboardUp;
            session.RecordKeyChar = recordKeyChar;
            session.MergeKeyChar = mergeKeyChar;

            if (recordWait)
                session.MinWaitTime = minWaitTime;
            else
                session.MinWaitTime = int.MaxValue;

            session.ExcludedKeys = hotkeys.AllKeyCodes;
            session.ExcludeKeys = hotkeys.Enabled && filterHotkeys;
        }

        public void LoadDefaults()
        {
            recordMouse = true;
            recordMouseUp = true;
            recordMouseMove = false;
            recordKeyboard = true;
            recordKeyboardUp = true;
            recordKeyChar = false;
            mergeKeyChar = false;
            recordWait = true;
            minWaitTime = 8;
            hotkeys.Enabled = false;
            hotkeys[0] = Keys.F7;
            hotkeys[1] = Keys.F8;
            hotkeys[2] = Keys.F9;
            clearOnRecord = true;
            toggleHotkeys = true;
            filterHotkeys = true;
        }

        public void Load()
        {
            Load(defaultFileName);
        }

        public void Load(string path)
        {
            if (!File.Exists(path))
                return;

            try
            {
                using (BinaryReader reader = new BinaryReader(File.OpenRead(path), Encoding.UTF8))
                {
                    recordMouse = reader.ReadBoolean();
                    recordMouseUp = reader.ReadBoolean();
                    recordMouseMove = reader.ReadBoolean();
                    recordKeyboard = reader.ReadBoolean();
                    recordKeyboardUp = reader.ReadBoolean();
                    recordKeyChar = reader.ReadBoolean();
                    mergeKeyChar = reader.ReadBoolean();
                    recordWait = reader.ReadBoolean();
                    minWaitTime = reader.ReadInt32();
                    hotkeys.Enabled = reader.ReadBoolean();

                    for (int i = 0; i < KEY_COUNT; i++)
                        hotkeys[i] = (Keys)reader.ReadInt32();

                    clearOnRecord = reader.ReadBoolean();
                    toggleHotkeys = reader.ReadBoolean();
                    filterHotkeys = reader.ReadBoolean();
                }
            }
            catch
            {
                Debug.Fail("Options.Load failed.");
                LoadDefaults();
            }
        }

        public void Save()
        {
            Save(defaultFileName);
        }

        public void Save(string path)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(path), Encoding.UTF8))
                {
                    writer.Write(recordMouse);
                    writer.Write(recordMouseUp);
                    writer.Write(recordMouseMove);
                    writer.Write(recordKeyboard);
                    writer.Write(recordKeyboardUp);
                    writer.Write(recordKeyChar);
                    writer.Write(mergeKeyChar);
                    writer.Write(recordWait);
                    writer.Write(minWaitTime);
                    writer.Write(hotkeys.Enabled);

                    for (int i = 0; i < KEY_COUNT; i++)
                        writer.Write((int)hotkeys[i]);

                    writer.Write(clearOnRecord);
                    writer.Write(toggleHotkeys);
                    writer.Write(filterHotkeys);
                }
            }
            catch
            {
                Debug.Fail("Options.Save failed.");
            }
        }

        public void Suspend()
        {
            hotkeys.UnregisterHotKeys();
        }

        public void Resume()
        {
            hotkeys.RegisterHotKeys();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                hotkeys.Dispose();
        }
    }
}
