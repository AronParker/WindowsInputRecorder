using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class KeyUpExtendedPacket : KeyboardPacket
    {
        public KeyUpExtendedPacket()
            : base(new KeyUpExtendedInput())
        {
        }

        public KeyUpExtendedPacket(KeyUpExtendedInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.KeyUpExtended; }
        }
    }
}
