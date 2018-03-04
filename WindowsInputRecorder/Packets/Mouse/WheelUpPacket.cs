using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class WheelUpPacket : MousePacket
    {
        public WheelUpPacket()
            : base(new WheelUpInput())
        {
        }

        public WheelUpPacket(WheelUpInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.WheelUp; }
        }
    }
}
