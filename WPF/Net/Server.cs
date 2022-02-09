using ChatServer.Behavioral.Net.IO;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WPF.Net
{
    public class Server
    {
        public TcpClient client;
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
                client.Connect("127.0.0.1", 7891); //trying to connect
                packetReader = new PacketReader(client.GetStream());

                if (!string.IsNullOrEmpty(username))    //sending to the server the user name of the user connected
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
                while (true)
                {
                    var opcode = packetReader.ReadByte();
                    switch (opcode)
                    {
                        case 1: //receive new users connected event
                            connectedEvent?.Invoke();
                            break;

                        case 5: //receive new messages from other user event
                            messageReceivedEvent?.Invoke();
                            break;
                        case 10:    //receive new user disconnected event
                            userDisconnectedEvent?.Invoke();
                            break;
                        default:
                            Console.WriteLine("Ah, yes");
                            break;
                    }
                }
            });
        }

        public virtual void SendMessageToServer(string message) //Sending message to the chat server aka the mediator
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteMessage(message);
            client.Client.Send(messagePacket.GetPacketBytes());
        }
    }
}
