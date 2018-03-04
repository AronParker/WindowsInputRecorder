using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class KeyDownExtendedPacket : KeyboardPacket
    {
        public KeyDownExtendedPacket()
            : base(new KeyDownExtendedInput())
        {
        }

        public KeyDownExtendedPacket(KeyDownExtendedInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.KeyDownExtended; }
        }
    }
}
