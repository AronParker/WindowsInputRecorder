using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class X1UpPacket : MousePacket
    {
        public X1UpPacket()
            : base(new X1UpInput())
        {
        }

        public X1UpPacket(X1UpInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.X1Up; }
        }
    }
}
