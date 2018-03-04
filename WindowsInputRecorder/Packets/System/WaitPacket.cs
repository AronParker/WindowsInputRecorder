using System.IO;

namespace WindowsInputRecorder.Packets
{
    public class WaitPacket : Packet
    {
        private int milliseconds;

        public WaitPacket()
        {
        }

        public WaitPacket(int millisecondsTimeout)
        {
            this.milliseconds = millisecondsTimeout;
        }

        public override PacketID ID
        {
            get { return PacketID.Wait; }
        }

        public int Milliseconds
        {
            get { return milliseconds; }
            set { milliseconds = value; }
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write(Milliseconds);
        }

        protected override void Read(BinaryReader reader)
        {
            Milliseconds = reader.ReadInt32();
        }

        public override int ArgsCount
        {
            get { return 2; }
        }

        protected override void Write(string[] args)
        {
            args[1] = Milliseconds.ToString();
            args[2] = "ms";
        }

        protected override void Read(string[] args)
        {
            checked
            {
                switch (args[2].ToLowerInvariant())
                {
                    case "ms":
                    case "millisecond":
                    case "milliseconds":
                    default:
                        Milliseconds = int.Parse(args[1]);
                        break;
                    case "s":
                    case "second":
                    case "seconds":
                        Milliseconds = 1000 * int.Parse(args[1]);
                        break;
                    case "m":
                    case "minute":
                    case "minutes":
                        Milliseconds = 60 * 1000 * int.Parse(args[1]);
                        break;
                    case "h":
                    case "hour":
                    case "hours":
                        Milliseconds = 60 * 60 * 1000 * int.Parse(args[1]);
                        break;
                    case "d":
                    case "day":
                    case "days":
                        Milliseconds = 24 * 60 * 60 * 1000 * int.Parse(args[1]);
                        break;
                }
            }
        }
    }
}
