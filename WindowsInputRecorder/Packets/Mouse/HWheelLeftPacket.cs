using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class HWheelLeftPacket : MousePacket
    {
        public HWheelLeftPacket()
            : base(new HWheelLeftInput())
        {
        }

        public HWheelLeftPacket(HWheelLeftInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.HWheelLeft; }
        }
    }
}
