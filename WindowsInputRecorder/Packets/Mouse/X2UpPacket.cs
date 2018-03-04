using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class X2UpPacket : MousePacket
    {
        public X2UpPacket()
            : base(new X2UpInput())
        {
        }

        public X2UpPacket(X2UpInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.X2Up; }
        }
    }
}
