using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class KeyPressPacket : KeyboardPacket
    {
        public KeyPressPacket()
            : base(new KeyPressInput())
        {
        }

        public KeyPressPacket(KeyPressInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.KeyPress; }
        }
    }
}
