using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Behavioral.Net.IO
{
    public class PacketReader : BinaryReader
    {
        public NetworkStream ns;

        public PacketReader(NetworkStream ns) : base(ns)
        {
            this.ns = ns;
        }

        public string ReadMessage()
        {
            byte[] messageBuffer;
            var length = ReadInt32();
            messageBuffer = new byte[length];
            ns.Read(messageBuffer, 0, length);
            string message = Encoding.ASCII.GetString(messageBuffer);

            return message;
        }

    }
}
