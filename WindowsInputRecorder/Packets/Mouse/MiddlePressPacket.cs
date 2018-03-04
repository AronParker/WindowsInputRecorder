using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class MiddlePressPacket : MousePacket
    {
        public MiddlePressPacket()
            : base(new MiddlePressInput())
        {
        }

        public MiddlePressPacket(MiddlePressInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.MiddleClick; }
        }
    }
}
