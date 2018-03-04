using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class MiddleUpPacket : MousePacket
    {
        public MiddleUpPacket()
            : base(new MiddleUpInput())
        {
        }

        public MiddleUpPacket(MiddleUpInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.MiddleUp; }
        }
    }
}
