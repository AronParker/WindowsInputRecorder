using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class KeyPressExtendedPacket : KeyboardPacket
    {
        public KeyPressExtendedPacket()
            : base(new KeyPressExtendedInput())
        {
        }

        public KeyPressExtendedPacket(KeyPressExtendedInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.KeyPressExtended; }
        }
    }
}
