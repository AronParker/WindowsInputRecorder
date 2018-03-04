using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Win32;
namespace WindowsInputRecorder.Inputs
{
    public class HardwareInput : Input
    {
        private uint uMsg;
        private ushort wParamL;
        private ushort wParamH;

        public HardwareInput()
        {
        }

        public HardwareInput(uint uMsg, ushort wParamL, ushort wParamH)
        {
            this.uMsg = uMsg;
            this.wParamL = wParamL;
            this.wParamH = wParamH;
        }

        public uint Message
        {
            get { return uMsg; }
            set { uMsg = value; }
        }

        public ushort ParamL
        {
            get { return wParamL; }
            set { wParamL = value; }
        }

        public ushort ParamH
        {
            get { return wParamH; }
            set { wParamH = value; }
        }

        public override Packet ToPacket()
        {
            return new HardwarePacket(this);
        }

        internal override void InternalQueue(SendInput sendInput)
        {
            INPUT input = new INPUT();
            input.type = 2;

            input.inputunion.hi.uMsg = Message;
            input.inputunion.hi.wParamL = ParamL;
            input.inputunion.hi.wParamH = ParamH;

            sendInput.InternalQueue(input);
        }
    }
}
