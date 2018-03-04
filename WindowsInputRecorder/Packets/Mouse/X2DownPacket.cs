using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class X2DownPacket : MousePacket
    {
        public X2DownPacket()
            : base(new X2DownInput())
        {
        }

        public X2DownPacket(X2DownInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.X2Down; }
        }
    }
}
