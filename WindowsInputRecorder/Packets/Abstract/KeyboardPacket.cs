using System;
using System.IO;
using System.Windows.Forms;
using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public abstract class KeyboardPacket : InputPacket
    {
        private KeyboardInput input;

        public KeyboardPacket(KeyboardInput input)
        {
            this.input = input;
        }

        public override Input Input
        {
            get { return input; }
            set { input = (KeyboardInput)value; }
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write((byte)input.Key);
        }

        protected override void Read(BinaryReader reader)
        {
            input.Key = (Keys)reader.ReadByte();
        }

        public override int ArgsCount
        {
            get { return 1; }
        }

        protected override void Write(string[] args)
        {
            args[1] = input.Key.ToString();
        }

        protected override void Read(string[] args)
        {
            input.Key = (Keys)Enum.Parse(typeof(Keys), args[1], true);
        }
    }
}
