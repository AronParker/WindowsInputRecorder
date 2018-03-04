using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class LeftUpPacket : MousePacket
    {
        public LeftUpPacket()
            : base(new LeftUpInput())
        {
        }

        public LeftUpPacket(LeftUpInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.LeftUp; }
        }
    }
}
