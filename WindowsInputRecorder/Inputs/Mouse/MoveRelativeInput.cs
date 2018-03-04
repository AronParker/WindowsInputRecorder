using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class MoveRelativeInput : MouseInput
    {
        public MoveRelativeInput()
        {
        }

        public MoveRelativeInput(int x, int y)
            : base(x, y)       
        {
        }

        public override Packet ToPacket()
        {
            return new MoveRelativePacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 0;
            input.inputunion.mi.dx = x;
            input.inputunion.mi.dy = y;
            input.inputunion.mi.dwFlags = MOUSEEVENTF.MOVE;

            sendInput.InternalQueue(input);
        }
    }
}
