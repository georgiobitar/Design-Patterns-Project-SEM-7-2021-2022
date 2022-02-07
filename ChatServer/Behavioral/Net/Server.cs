using ChatServer.Behavioral.Net.IO;
using System.Net.Sockets;

namespace ChatServer.Behavioral
{
    public class Server
    {
        TcpClient client;
        public Server()
        {
            this.client = new TcpClient();
        }

        public void ConnectToServer(string username)
        {
            if(!client.Connected)
            {
                client.Connect("127.0.0.1", 7891);
                var connectPacket = new PacketBuilder();
                connectPacket.WriteOpCode(0);
                connectPacket.WriteString(username);
                client.Client.Send(connectPacket.GetPacketBytes());
            }
        }
    }
}
