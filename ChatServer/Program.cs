
using ChatServer.Behavioral;
using ChatServer.Behavioral.Net;
using ChatServer.Behavioral.Net.IO;
using System;
using System.Net.Sockets;

namespace ChatServer
{
    class Program
    {
        static ChatRoom room;
        static void Main(string[] args)
        {
            room = new UserChatRoom();
            room.RegisterUsers();
        }

        public static void BroadcastConnection()
        {
            room.BroadcastConnection();
        }

        public static void BroadcastMessage(string message)
        {
            room.BroadcastMessage(message);
        }

        public static void BroadcastDisconnection(string username)
        {
            room.BroadcastDisconnection(username);
        }


    }
}