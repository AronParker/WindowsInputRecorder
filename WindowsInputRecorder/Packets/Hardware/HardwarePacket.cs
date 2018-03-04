using System;
using System.IO;
using WindowsInputRecorder.Inputs;

namespace WindowsInputRecorder.Packets
{
    public class HardwarePacket : InputPacket
    {
        private HardwareInput input;

        public HardwarePacket()
        {
            this.input = new HardwareInput();
        }

        public HardwarePacket(HardwareInput input)
        {
            this.input = input;
        }

        public override Input Input
        {
            get { return input; }
            set { input = (HardwareInput)value; }
        }

        public override PacketID ID
        {
            get { return PacketID.Hardware; }
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write(input.Message);
            writer.Write(input.ParamL);
            writer.Write(input.ParamH);
        }

        protected override void Read(BinaryReader reader)
        {
            input.Message = reader.ReadUInt32();
            input.ParamL = reader.ReadUInt16();
            input.ParamH = reader.ReadUInt16();
        }

        public override int ArgsCount
        {
            get { return 3; }
        }

        protected override void Write(string[] args)
        {
            args[1] = input.Message.ToString();
            args[2] = input.ParamL.ToString();
            args[3] = input.ParamH.ToString();
        }

        protected override void Read(string[] args)
        {
            input.Message = UInt32.Parse(args[1]);
            input.ParamL = UInt16.Parse(args[2]);
            input.ParamH = UInt16.Parse(args[3]);
        }
    }
}
