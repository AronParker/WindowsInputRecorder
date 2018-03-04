using System.Windows.Forms;
using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class KeyPressExtendedInput : KeyboardInput
    {
        public KeyPressExtendedInput()
        {
        }

        public KeyPressExtendedInput(Keys key)
            : base(key)
        {
        }

        public override Packet ToPacket()
        {
            return new KeyPressExtendedPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 1;
            input.inputunion.ki.wVk = (ushort)key;
            input.inputunion.ki.dwFlags = KEYEVENTF.EXTENDEDKEY;

            sendInput.InternalQueue(input);

            input.inputunion.ki.dwFlags = KEYEVENTF.EXTENDEDKEY | KEYEVENTF.KEYUP;

            sendInput.InternalQueue(input);
        }
    }
}
