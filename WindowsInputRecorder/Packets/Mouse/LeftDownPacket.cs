using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class LeftDownPacket : MousePacket
    {
        public LeftDownPacket()
            : base(new LeftDownInput())
        {
        }

        public LeftDownPacket(LeftDownInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.LeftDown; }
        }
    }
}
