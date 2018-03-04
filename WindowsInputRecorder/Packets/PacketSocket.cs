using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WindowsInputRecorder.Packets
{
    public class PacketSocket : IDisposable
    {
        private Socket socket;
        private NetworkStream network;
        private BinaryReader reader;
        private BinaryWriter writer;
        private Thread recvThread;
        private bool receiving;

        public PacketSocket(Socket socket)
        {
            this.socket = socket;
            this.network = new NetworkStream(socket, false);
            this.reader = new BinaryReader(network, Encoding.UTF8);
            this.writer = new BinaryWriter(network, Encoding.UTF8);
        }

        ~PacketSocket()
        {
            Dispose(false);
        }

        public event PacketHandler PacketReceived;
        public event EventHandler ReceivingStopped;

        public Socket Client
        {
            get { return socket; }
        }

        public void Send(Packet packet)
        {
            packet.WriteToBinaryWriter(writer);
        }

        public Packet Receive()
        {
            return Packet.FromBinaryReader(reader);
        }

        public void Start()
        {
            if (receiving)
                return;

            receiving = true;
            recvThread = new Thread(ReceiveThread);
        }

        public void Stop()
        {
            receiving = false;
            recvThread.Join();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Close()
        {
            this.Stop();
            this.socket.Close();
            this.network.Close();
            this.reader.Close();
            this.writer.Close();
        }

        protected virtual void OnPacketReceived(Packet packet)
        {
            if (PacketReceived != null)
                PacketReceived(packet);
        }

        protected virtual void OnReceivingStopped()
        {
            if (ReceivingStopped != null)
                ReceivingStopped(this, EventArgs.Empty);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Close();
        }

        private void ReceiveThread()
        {
            try
            {
                while (receiving)
                {
                    Packet packet = Receive();

                    if (receiving)
                        OnPacketReceived(packet);
                }

                OnReceivingStopped();
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
                OnReceivingStopped();
            }
        }
    }
}
