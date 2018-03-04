using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class KeyCharInput : Input
    {
        private char c;

        public KeyCharInput()
        {
        }

        public KeyCharInput(char c)
        {
            this.c = c;
        }

        public char Character
        {
            get { return c; }
            set { c = value; }
        }

        public override Packet ToPacket()
        {
            return new KeyCharPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            
            input.type = 1;
            input.inputunion.ki.wScan = c;
            input.inputunion.ki.dwFlags = KEYEVENTF.UNICODE;

            sendInput.InternalQueue(input);
        }
    }
}
