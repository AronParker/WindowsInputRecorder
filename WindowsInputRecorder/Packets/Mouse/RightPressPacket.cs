using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class RightPressPacket : MousePacket
    {
        public RightPressPacket()
            : base(new RightPressInput())
        {
        }

        public RightPressPacket(RightPressInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.RightClick; }
        }
    }
}
