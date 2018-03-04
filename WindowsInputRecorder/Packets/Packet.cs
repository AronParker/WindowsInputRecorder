using WindowsInputRecorder.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsInputRecorder.Packets
{
    public delegate void PacketHandler(Packet packet);

    public abstract class Packet
    {
        public static Packet FromBinaryReader(BinaryReader binaryReader)
        {
            PacketID id = (PacketID)binaryReader.ReadByte();
            Packet packet = GetNewPacketById(id);
            packet.Read(binaryReader);
            return packet;
        }

        public static Packet FromDataFile(string path)
        {
            FileStream fileStream = File.OpenRead(path);

            using (BinaryReader reader = new BinaryReader(fileStream, Encoding.UTF8))
                return FromBinaryReader(reader);
        }

        public static Packet FromArray(byte[] buffer)
        {
            return FromArray(buffer, 0, buffer.Length);
        }

        public static Packet FromArray(byte[] buffer, int index, int count)
        {
            MemoryStream memoryStream = new MemoryStream(buffer, index, count);

            using (BinaryReader reader = new BinaryReader(memoryStream, Encoding.UTF8))
                return FromBinaryReader(reader);
        }

        public static Packet FromString(string s)
        {
            string[] args = InternalSplit(s);
            PacketID id;

            try
            {
                id = (PacketID)Enum.Parse(typeof(PacketID), args[0], true);
            }
            catch (Exception ex)
            {
                throw new Exception("Method name not found: " + args[0] + ".", ex);
            }

            Packet packet = GetNewPacketById(id);

            if (args.Length <= packet.ArgsCount)
                throw new Exception("Insufficient Arguments given.");

            try
            {
                packet.Read(args);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid Arguments specified.", ex);
            }

            return packet;
        }

        public static Packet FromScriptFile(string path)
        {
            return FromString(File.ReadAllText(path, Encoding.UTF8));
        }

        public void WriteToBinaryWriter(BinaryWriter binaryWriter)
        {
            binaryWriter.Write((byte)ID);
            Write(binaryWriter);
        }

        public byte[] WriteToArray()
        {
            MemoryStream memoryStream = new MemoryStream();
            byte[] result;

            using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.UTF8))
            {
                WriteToBinaryWriter(binaryWriter);
                result = memoryStream.ToArray();
            }

            return result;
        }

        public void WriteToDataFile(string path)
        {
            FileStream fileStream = File.OpenWrite(path);

            using (BinaryWriter writer = new BinaryWriter(fileStream, Encoding.UTF8))
                WriteToBinaryWriter(writer);
        }

        public string WriteToString()
        {
            string[] args = new string[ArgsCount + 1];
            args[0] = ID.ToString();
            Write(args);
            return String.Join(" ", args);
        }

        public void WriteToScriptFile(string path)
        {
            File.WriteAllText(path, WriteToString(), Encoding.UTF8);
        }

        public override string ToString()
        {
            return WriteToString();
        }

        internal static Packet GetNewPacketById(PacketID id)
        {
            switch (id)
            {
                case PacketID.Wait:
                    return new WaitPacket();
                case PacketID.KeyDown:
                    return new KeyDownPacket();
                case PacketID.KeyDownExtended:
                    return new KeyDownExtendedPacket();
                case PacketID.KeyUp:
                    return new KeyUpPacket();
                case PacketID.KeyUpExtended:
                    return new KeyUpExtendedPacket();
                case PacketID.KeyPress:
                    return new KeyPressPacket();
                case PacketID.KeyPressExtended:
                    return new KeyPressExtendedPacket();
                case PacketID.Move:
                    return new MovePacket();
                case PacketID.MoveRelative:
                    return new MoveRelativePacket();
                case PacketID.LeftDown:
                    return new LeftDownPacket();
                case PacketID.LeftUp:
                    return new LeftUpPacket();
                case PacketID.RightDown:
                    return new RightDownPacket();
                case PacketID.RightUp:
                    return new RightUpPacket();
                case PacketID.MiddleDown:
                    return new MiddleDownPacket();
                case PacketID.MiddleUp:
                    return new MiddleUpPacket();
                case PacketID.WheelDown:
                    return new WheelDownPacket();
                case PacketID.WheelUp:
                    return new WheelUpPacket();
                case PacketID.X1Down:
                    return new X1DownPacket();
                case PacketID.X2Down:
                    return new X2DownPacket();
                case PacketID.X1Up:
                    return new X1UpPacket();
                case PacketID.X2Up:
                    return new X2UpPacket();
                case PacketID.HWheelLeft:
                    return new HWheelLeftPacket();
                case PacketID.HWheelRight:
                    return new HWheelRightPacket();
                case PacketID.LeftClick:
                    return new LeftPressPacket();
                case PacketID.RightClick:
                    return new RightPressPacket();
                case PacketID.MiddleClick:
                    return new MiddlePressPacket();
                case PacketID.X1Click:
                    return new X1PressPacket();
                case PacketID.X2Click:
                    return new X2PressPacket();
                case PacketID.Hardware:
                    return new HardwarePacket();
                case PacketID.SendChar:
                    return new KeyCharPacket();
                case PacketID.SendText:
                    return new SendTextPacket();
                default:
                    throw new Exception("PacketID not found: " + id.ToString());
            }
        }

        public abstract PacketID ID { get; }

        protected abstract void Write(BinaryWriter writer);

        protected abstract void Read(BinaryReader reader);

        public abstract int ArgsCount { get; }

        protected abstract void Write(string[] args);

        protected abstract void Read(string[] args);

        private static string[] InternalSplit(string s)
        {
            int pNumArgs;
            IntPtr ptr = NativeMethods.CommandLineToArgvW(s, out pNumArgs);
            
            if (ptr == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            string[] result = new string[pNumArgs];
            
            try
            {
                for (int i = 0; i < pNumArgs; i++)
                    result[i] = Marshal.PtrToStringUni(Marshal.ReadIntPtr(ptr, i * IntPtr.Size));
            }
            finally
            {
                NativeMethods.LocalFree(ptr);
            }

            return result;
        }
    }
}
