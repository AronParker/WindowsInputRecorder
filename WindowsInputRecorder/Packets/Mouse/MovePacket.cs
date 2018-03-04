using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class MovePacket : MousePacket
    {
        public MovePacket()
            : base(new MoveInput())
        {
        }

        public MovePacket(MoveInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.Move; }
        }
    }
}
