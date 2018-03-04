using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class HWheelRightPacket : MousePacket
    {
        public HWheelRightPacket()
            : base(new HWheelRightInput())
        {
        }

        public HWheelRightPacket(HWheelRightInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.HWheelRight; }
        }
    }
}
