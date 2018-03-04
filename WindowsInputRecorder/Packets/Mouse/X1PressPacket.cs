using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class X1PressPacket : MousePacket
    {
        public X1PressPacket()
            : base(new X1PressInput())
        {
        }

        public X1PressPacket(X1PressInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.X1Click; }
        }
    }
}
