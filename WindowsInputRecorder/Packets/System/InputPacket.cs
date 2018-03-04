using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public abstract class InputPacket : Packet
    {
        public abstract Input Input { get; set; }
    }
}
