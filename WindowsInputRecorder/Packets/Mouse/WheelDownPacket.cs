using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class WheelDownPacket : MousePacket
    {
        public WheelDownPacket()
            : base(new WheelDownInput())
        {
        }

        public WheelDownPacket(WheelDownInput input)
            : base(input)
        {
        }

        public override PacketID ID
        {
            get { return PacketID.WheelDown; }
        }
    }
}
