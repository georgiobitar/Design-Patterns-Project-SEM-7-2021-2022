using ChatServer.Behavioral.Net.IO;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WPF.Net
{
    public class NormalServer : Server
    {
        
        public NormalServer() : base()
        {
            
        }

        public override void SendMessageToServer(string message)    //overriding the normal server message sending for the normal user
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteMessage(" - (Normal User) - " + message);
            base.client.Client.Send(messagePacket.GetPacketBytes());
        }
    }
}
