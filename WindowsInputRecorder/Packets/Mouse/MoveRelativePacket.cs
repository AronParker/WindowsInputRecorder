using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class MoveRelativePacket : MousePacket
    {
        public MoveRelativePacket()
            : base(new MoveRelativeInput())
        {
        }

        public MoveRelativePacket(MoveRelativeInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.MoveRelative; }
        }
    }
}
