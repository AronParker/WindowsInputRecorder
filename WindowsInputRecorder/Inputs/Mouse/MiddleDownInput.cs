﻿using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class MiddleDownInput : MouseInput
    {
        public MiddleDownInput()
        {
        }

        public MiddleDownInput(int x, int y)
            : base(x, y)       
        {
        }

        public override Packet ToPacket()
        {
            return new MiddleDownPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 0;
            input.inputunion.mi.dx = x * 65535 / MouseInput.MaxWidth;
            input.inputunion.mi.dy = y * 65535 / MouseInput.MaxHeight;
            input.inputunion.mi.dwFlags = MOUSEEVENTF.MOVE | MOUSEEVENTF.MIDDLEDOWN | MOUSEEVENTF.ABSOLUTE;

            sendInput.InternalQueue(input);
        }
    }
}
