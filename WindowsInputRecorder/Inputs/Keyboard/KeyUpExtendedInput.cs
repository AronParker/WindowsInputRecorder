﻿using System.Windows.Forms;
using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public class KeyUpExtendedInput : KeyboardInput
    {
        public KeyUpExtendedInput()
        {
        }

        public KeyUpExtendedInput(Keys key)
            : base(key)
        {
        }

        public override Packet ToPacket()
        {
            return new KeyUpExtendedPacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 1;
            input.inputunion.ki.wVk = (ushort)key;
            input.inputunion.ki.dwFlags = KEYEVENTF.EXTENDEDKEY | KEYEVENTF.KEYUP;

            sendInput.InternalQueue(input);
        }
    }
}
