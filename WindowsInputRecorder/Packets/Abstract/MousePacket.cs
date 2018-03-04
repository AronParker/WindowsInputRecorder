using WindowsInputRecorder.Inputs;
using System;
using System.IO;

namespace WindowsInputRecorder.Packets
{
    public abstract class MousePacket : InputPacket
    {
        private MouseInput input;

        public MousePacket()
        {
        }

        public MousePacket(MouseInput input)
        {
            this.input = input;
        }

        public override Input Input
        {
            get { return input; }
            set { input = (MouseInput)value; }
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write((short)input.X);
            writer.Write((short)input.Y);
        }

        protected override void Read(BinaryReader reader)
        {
            input.X = reader.ReadInt16();
            input.Y = reader.ReadInt16();
        }

        public override int ArgsCount
        {
            get { return 2; }
        }

        protected override void Write(string[] args)
        {
            args[1] = input.X.ToString();
            args[2] = input.Y.ToString();
        }

        protected override void Read(string[] args)
        {
            input.X = Int16.Parse(args[1]);
            input.Y = Int16.Parse(args[2]);
        }
    }
}
