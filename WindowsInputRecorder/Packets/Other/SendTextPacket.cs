using WindowsInputRecorder.Inputs;
using System.IO;

namespace WindowsInputRecorder.Packets
{
    public class SendTextPacket : InputPacket
    {
        private SendTextInput input;

        public SendTextPacket()
        {
            this.input = new SendTextInput();
        }

        public SendTextPacket(SendTextInput sendTextInput)
        {
            this.input = sendTextInput;
        }

        public override Input Input
        {
            get { return input; }
            set { input = (SendTextInput)value; }
        }

        public override PacketID ID
        {
            get { return PacketID.SendText; }
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write(input.Text);
        }

        protected override void Read(BinaryReader reader)
        {
            input.Text = reader.ReadString();
        }

        public override int ArgsCount
        {
            get { return 1; }
        }

        protected override void Write(string[] args)
        {
            args[1] = '\"' + input.Text.ToString() + '\"';
        }

        protected override void Read(string[] args)
        {
            input.Text = args[1];
        }
    }
}
