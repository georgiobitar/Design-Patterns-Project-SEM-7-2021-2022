using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Behavioral.Net
{
    public abstract class ChatRoom
    {
        public abstract void RegisterUsers();
        public abstract void BroadcastConnection();
        public abstract void BroadcastMessage(string message);
        public abstract void BroadcastDisconnection(string username);
    }
}
