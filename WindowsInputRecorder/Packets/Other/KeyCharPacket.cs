using WindowsInputRecorder.Inputs;
using System;
using System.IO;

namespace WindowsInputRecorder.Packets
{
    public class KeyCharPacket : InputPacket
    {
        private KeyCharInput input;

        public KeyCharPacket()
        {
            this.input = new KeyCharInput();
        }

        public KeyCharPacket(KeyCharInput input)
        {
            this.input = input;
        }

        public override Input Input
        {
            get { return input; }
            set { input = (KeyCharInput)value; }
        }

        public override PacketID ID
        {
            get { return PacketID.SendChar; }
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write((ushort)input.Character);
        }

        protected override void Read(BinaryReader reader)
        {
            input.Character = (char)reader.ReadUInt16();
        }

        public override int ArgsCount
        {
            get { return 1; }
        }

        protected override void Write(string[] args)
        {
            args[1] = input.Character.ToString();
        }

        protected override void Read(string[] args)
        {
            input.Character = Char.Parse(args[1]);
        }
    }
}
