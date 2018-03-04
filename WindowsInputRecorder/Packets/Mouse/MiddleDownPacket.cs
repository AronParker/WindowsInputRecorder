using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class MiddleDownPacket : MousePacket
    {
        public MiddleDownPacket()
            : base(new MiddleDownInput())
        {
        }

        public MiddleDownPacket(MiddleDownInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.MiddleDown; }
        }
    }
}
