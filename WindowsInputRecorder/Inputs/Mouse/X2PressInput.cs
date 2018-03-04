using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class X2PressInput : MouseInput
    {
        public X2PressInput()
        {
        }

        public X2PressInput(int x, int y)
            : base(x, y)
        {
        }

        public override Packet ToPacket()
        {
            return new X2PressPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 0;
            input.inputunion.mi.dx = x * 65535 / MouseInput.MaxWidth;
            input.inputunion.mi.dy = y * 65535 / MouseInput.MaxHeight;
            input.inputunion.mi.mouseData = 2;
            input.inputunion.mi.dwFlags = MOUSEEVENTF.MOVE | MOUSEEVENTF.XDOWN | MOUSEEVENTF.XUP | MOUSEEVENTF.ABSOLUTE;

            sendInput.InternalQueue(input);
        }
    }
}
