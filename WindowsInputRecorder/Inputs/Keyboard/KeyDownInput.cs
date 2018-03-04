using System.Windows.Forms;
using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class KeyDownInput : KeyboardInput
    {
        public KeyDownInput()
        {
        }

        public KeyDownInput(Keys key)
            : base(key)
        {
        }

        public override Packet ToPacket()
        {
            return new KeyDownPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 1;
            input.inputunion.ki.wVk = (ushort)key;
            input.inputunion.ki.dwFlags = 0;

            sendInput.InternalQueue(input);
        }
    }
}
