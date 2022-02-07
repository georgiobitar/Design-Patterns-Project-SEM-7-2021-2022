using System.Net.Sockets;

namespace ChatServer.Behavioral
{
    public class NormalMember : TeamMember
    {
        TcpClient _client;
        public NormalMember(string name) : base(name)
        {
            _client = new TcpClient();
        }

        public override void Receive(string from, string message)
        {
            Console.Write($"{this.Name} ({nameof(NormalMember)}) has received: ");
            base.Receive(from, message);
        }

        public void ConnectToServer()
        {
            if(!_client.Connected)
            {
                _client.Connect("127.0.0.1", 7891);
            }
        }
    }
}
