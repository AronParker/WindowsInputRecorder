using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class RightUpPacket : MousePacket
    {
        public RightUpPacket()
            : base(new RightUpInput())
        {
        }

        public RightUpPacket(RightUpInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.RightUp; }
        }
    }
}
