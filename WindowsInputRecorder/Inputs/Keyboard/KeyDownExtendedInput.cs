using System.Windows.Forms;
using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class KeyDownExtendedInput : KeyboardInput
    {
        public KeyDownExtendedInput()
        {
        }

        public KeyDownExtendedInput(Keys key)
            : base(key)
        {
        }

        public override Packet ToPacket()
        {
            return new KeyDownExtendedPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 1;
            input.inputunion.ki.wVk = (ushort)key;
            input.inputunion.ki.dwFlags = KEYEVENTF.EXTENDEDKEY;

            sendInput.InternalQueue(input);
        }
    }
}
