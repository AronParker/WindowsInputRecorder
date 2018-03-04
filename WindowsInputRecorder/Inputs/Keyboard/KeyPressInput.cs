using System.Windows.Forms;
using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class KeyPressInput : KeyboardInput
    {
        public KeyPressInput()
        {
        }

        public KeyPressInput(Keys key)
            : base(key)
        {
        }

        public override Packet ToPacket()
        {
            return new KeyPressPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 1;
            input.inputunion.ki.wVk = (ushort)key;
            input.inputunion.ki.dwFlags = 0;

            sendInput.InternalQueue(input);

            input.inputunion.ki.dwFlags = KEYEVENTF.KEYUP;

            sendInput.InternalQueue(input);
        }
    }
}
