using ChatServer.Behavioral.Net.IO;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WPF.Net
{
    public class Server
    {
        TcpClient client;
        public PacketReader packetReader;
        public event Action connectedEvent;
        public event Action messageReceivedEvent;
        public event Action userDisconnectedEvent;
        public Server()
        {
            this.client = new TcpClient();
        }

        public void ConnectToServer(string username)
        {
            if (!client.Connected)
            {
                client.Connect("127.0.0.1", 7891);
                packetReader = new PacketReader(client.GetStream());

                if (!string.IsNullOrEmpty(username))
                {
                    var connectPacket = new PacketBuilder();
                    connectPacket.WriteOpCode(0);
                    connectPacket.WriteMessage(username);
                    client.Client.Send(connectPacket.GetPacketBytes());
                }
                ReadPackets();

            }
        }
        private void ReadPackets()
        {
            Task.Run(() =>
            {
                while(true)
                {
                    var opcode = packetReader.ReadByte();
                    switch(opcode)
                    {
                        case 1:
                            connectedEvent?.Invoke();
                            break;

                        case 5:
                            messageReceivedEvent?.Invoke();
                            break;
                        case 10:
                            userDisconnectedEvent?.Invoke();
                            break;
                        default:
                            Console.WriteLine("Ah, yes");
                            break;
                    }
                }
            });
        }

        public void SendMessageToServer(string message)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteMessage(message);
            client.Client.Send(messagePacket.GetPacketBytes());
        }
    }
}
