using WindowsInputRecorder.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WindowsInputRecorder.Packets
{
    public class PacketList : List<Packet>
    {
        public static PacketList FromBinaryReader(BinaryReader binaryReader)
        {
            PacketList result = new PacketList();
            result.AddFromBinaryReader(binaryReader);
            return result;
        }

        public static PacketList FromArray(byte[] buffer)
        {
            PacketList result = new PacketList();
            result.AddFromArray(buffer);
            return result;
        }

        public static PacketList FromArray(byte[] buffer, int index, int count)
        {
            PacketList result = new PacketList();
            result.AddFromArray(buffer, index, count);
            return result;
        }

        public static PacketList FromDataFile(string path)
        {
            PacketList result = new PacketList();
            result.AddFromDataFile(path);
            return result;
        }

        public static PacketList FromString(string s)
        {
            PacketList result = new PacketList();
            result.AddFromString(s);
            return result;
        }

        public static PacketList FromScriptFile(string path)
        {
            PacketList result = new PacketList();
            result.AddFromScriptFile(path);
            return result;
        }

        public void AddFromBinaryReader(BinaryReader binaryReader)
        {
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                Add(Packet.FromBinaryReader(binaryReader));
        }

        public void AddFromArray(byte[] buffer)
        {
            AddFromArray(buffer, 0, buffer.Length);
        }

        public void AddFromArray(byte[] buffer, int index, int count)
        {
            MemoryStream memoryStream = new MemoryStream(buffer, index, count);
            
            using (BinaryReader reader = new BinaryReader(memoryStream,Encoding.UTF8))
                AddFromBinaryReader(reader);
        }

        public void AddFromDataFile(string path)
        {
            FileStream fileStream = File.OpenRead(path);

            using (BinaryReader reader = new BinaryReader(fileStream, Encoding.UTF8))
                AddFromBinaryReader(reader);
        }

        public void AddFromString(string s)
        {
            using (StringReader stringReader = new StringReader(s))
                InternalAddFromTextReader(stringReader);
        }

        public void AddFromScriptFile(string path)
        {
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8, true))
                InternalAddFromTextReader(streamReader);
        }

        public void WriteToBinaryWriter(BinaryWriter binaryWriter)
        {
            for (int i = 0; i < Count; i++)
                this[i].WriteToBinaryWriter(binaryWriter);
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
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Count; i++)
                sb.AppendLine(this[i].ToString());

            return sb.ToString();
        }

        public void WriteToScriptFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
                for (int i = 0; i < Count; i++)
                    writer.WriteLine(this[i].ToString());
        }

        public override string ToString()
        {
            return WriteToString();
        }

        private void InternalAddFromTextReader(TextReader textReader)
        {
            string line = String.Empty;
            int lineIndex = 0;

            try
            {

                while ((line = textReader.ReadLine()) != null)
                {
                    if (IsNullOrWhiteSpace(line))
                        continue;

                    Add(Packet.FromString(line));

                    lineIndex++;
                }
            }
            catch (Exception ex)
            {
                throw new LineException(lineIndex, line, ex);
            }
        }

        private static bool IsNullOrWhiteSpace(string value)
        {
            if (value == null)
                return true;

            for (int index = 0; index < value.Length; ++index)
            {
                if (!char.IsWhiteSpace(value[index]))
                    return false;
            }

            return true;
        }
    }
}
