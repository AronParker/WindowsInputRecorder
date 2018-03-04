using WindowsInputRecorder.Packets;

namespace WindowsInputRecorder.Inputs
{
    public abstract class Input
    {
        public abstract Packet ToPacket();

        internal abstract void InternalQueue(SendInput sendInput);
    }
}
