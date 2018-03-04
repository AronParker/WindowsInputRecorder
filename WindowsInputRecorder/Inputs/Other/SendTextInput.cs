using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class SendTextInput : Input
    {
        private string s;

        public SendTextInput()
        {
        }

        public SendTextInput(string s)
        {
            this.s = s;
        }

        public string Text
        {
            get { return s; }
            set { s = value; }
        }

        public override Packet ToPacket()
        {
            return new SendTextPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT[] inputArray = new INPUT[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                inputArray[i].type = 1;
                inputArray[i].inputunion.ki.wScan = s[i];
                inputArray[i].inputunion.ki.dwFlags = KEYEVENTF.UNICODE;
            }
            
            sendInput.InternalQueue(inputArray);
        }
    }
}
