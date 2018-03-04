using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class KeyDownPacket : KeyboardPacket
    {
        public KeyDownPacket()
            : base(new KeyDownInput())
        {
        }

        public KeyDownPacket(KeyDownInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.KeyDown; }
        }
    }
}
