using ChatServer.Behavioral.Net.IO;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WPF.Net
{
    public class AdminServer : Server
    {

        public AdminServer() : base()
        {

        }

        public override void SendMessageToServer(string message)    //overriding the normal server message sending for the normal user
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteMessage(" - (Admin) - " + message);
            base.client.Client.Send(messagePacket.GetPacketBytes());
        }
    }
}
