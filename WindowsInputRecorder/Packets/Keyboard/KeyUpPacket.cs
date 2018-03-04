using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class KeyUpPacket : KeyboardPacket
    {
        public KeyUpPacket()
            : base(new KeyUpInput())
        {
        }

        public KeyUpPacket(KeyUpInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.KeyUp; }
        }
    }
}
