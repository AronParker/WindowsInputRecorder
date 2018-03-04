using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class X2PressPacket : MousePacket
    {
        public X2PressPacket()
            : base(new X2PressInput())
        {
        }

        public X2PressPacket(X2PressInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.X2Click; }
        }
    }
}
