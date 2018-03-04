using System.Windows.Forms;
using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class KeyUpInput : KeyboardInput
    {
        public KeyUpInput()
        {
        }

        public KeyUpInput(Keys key)
            : base(key)
        {
        }

        public override Packet ToPacket()
        {
            return new KeyUpPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 1;
            input.inputunion.ki.wVk = (ushort)key;
            input.inputunion.ki.dwFlags = KEYEVENTF.KEYUP;

            sendInput.InternalQueue(input);
        }
    }
}
