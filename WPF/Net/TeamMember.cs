//using ChatServer.Behavioral;
//using System.Net.Sockets;

//namespace WPF.Net
//{
//    public abstract class TeamMember
//    {
//        private ChatRoom chatroom;
//        public string Name { get; set; }
//        public TeamMember(string name)
//        {
//            this.Name = name;
           
//        }
//        internal void SetChatroom(ChatRoom chatroom)
//        {
//            this.chatroom = chatroom;
//        }

//        public void Send(string message)
//        {
//            this.chatroom.Send(this.Name, message);
//        }

//        public virtual void Receive(string from, string message)
//        {
//            //Console.WriteLine($"from {from}: '{message}'");
//        }
//    }
//}
