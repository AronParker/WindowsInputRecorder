using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class X1DownPacket : MousePacket
    {
        public X1DownPacket()
            : base(new X1DownInput())
        {
        }

        public X1DownPacket(X1DownInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.X1Down; }
        }
    }
}
