
using ChatServer.Behavioral.Net.IO;
using System;
using System.Net.Sockets;

namespace ChatServer.Behavioral.Net
{
    class UserChatRoom : ChatRoom
    {
        static List<Client> _users;
        static TcpListener _listener;

        public override void RegisterUsers()
        {
            _users = new List<Client>();
            _listener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 7891);
            _listener.Start();

            while (true)
            {
                var client = new Client(_listener.AcceptTcpClient());   //creating a new client(socket) for every user
                _users.Add(client);
                //Console.WriteLine("Client has connected!");
                BroadcastConnection();
            }
        }

        public override void BroadcastConnection()
        {
            foreach (var user in _users)
            {
                foreach (var usr in _users)
                {
                    var broadcastPacket = new PacketBuilder();
                    broadcastPacket.WriteOpCode(1);
                    broadcastPacket.WriteMessage(usr.Username);
                    broadcastPacket.WriteMessage(usr.UID.ToString());
                    user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
                }
            }
        }

        public override void BroadcastMessage(string message)
        {
            foreach (var user in _users)
            {
                var msgPacket = new PacketBuilder();
                msgPacket.WriteOpCode(5);
                msgPacket.WriteMessage(message);
                user.ClientSocket.Client.Send(msgPacket.GetPacketBytes());
            }
        }

        public override void BroadcastDisconnection(string username)
        {
            var disconnectedUser = _users.Where(x => x.Username == username).FirstOrDefault();
            _users.Remove(disconnectedUser);
            foreach (var user in _users)
            {
                var broadcastPacket = new PacketBuilder();
                broadcastPacket.WriteOpCode(10);
                broadcastPacket.WriteMessage(username);
                user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
            }

            BroadcastMessage($"[{disconnectedUser.Username}] Disconnected!");
        }
    }
}