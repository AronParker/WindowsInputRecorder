using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class LeftPressPacket : MousePacket
    {
        public LeftPressPacket()
            : base(new LeftPressInput())
        {
        }

        public LeftPressPacket(LeftPressInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.LeftClick; }
        }
    }
}
