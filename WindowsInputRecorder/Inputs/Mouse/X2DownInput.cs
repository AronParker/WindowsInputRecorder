using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class X2DownInput : MouseInput
    {
        public X2DownInput()
        {
        }

        public X2DownInput(int x, int y)
            : base(x, y)
        {
        }

        public override Packet ToPacket()
        {
            return new X2DownPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 0;
            input.inputunion.mi.dx = x * 65535 / MouseInput.MaxWidth;
            input.inputunion.mi.dy = y * 65535 / MouseInput.MaxHeight;
            input.inputunion.mi.dwFlags = MOUSEEVENTF.MOVE | MOUSEEVENTF.XDOWN | MOUSEEVENTF.ABSOLUTE;
            input.inputunion.mi.mouseData = 2;

            sendInput.InternalQueue(input);
        }
    }
}
