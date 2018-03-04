using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class RightDownPacket : MousePacket
    {
        public RightDownPacket()
            : base(new RightDownInput())
        {
        }

        public RightDownPacket(RightDownInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.RightDown; }
        }
    }
}
