using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ChatServer.Behavioral;
using Infrastructure.Models;
using WPF.Core;
using WPF.Net;

namespace WPF.ViewModel
{
    public class MainViewModel
    {
        public RelayCommand ConnectToServerCommand { get; set; }
        public RelayCommand SendMessageCommand { get; set; }
        public string  Username { get; set; }
        public string  Message { get; set; }
        public ObservableCollection<string> Messages { get; set; }
        public ObservableCollection<User> Users { get; set; }
        private Server server;
        public MainViewModel()
        {
            Users = new ObservableCollection<User>();
            Messages = new ObservableCollection<string>();
            this.server = new Server();
            this.server.connectedEvent += UserConnected;
            this.server.messageReceivedEvent += MessageReceived;
            this.server.userDisconnectedEvent += UserDisconnected;
            ConnectToServerCommand = new RelayCommand(o => this.server.ConnectToServer(Username), o => !string.IsNullOrEmpty(Username));
            SendMessageCommand = new RelayCommand(o => this.server.SendMessageToServer(Message), o => !string.IsNullOrEmpty(Message));
        }

        private void UserDisconnected()
        {
            var username = this.server.packetReader.ReadMessage();
            var user = Users.Where(x => x.UserName == username).FirstOrDefault();
            Application.Current.Dispatcher.Invoke(() => Users.Remove(user));
        }

        private void MessageReceived()
        {
            var message = this.server.packetReader.ReadMessage();
            Application.Current.Dispatcher.Invoke(() => Messages.Add(message));
        }

        private void UserConnected()
        {
            var user = new User
            {
                UserName = this.server.packetReader.ReadMessage(),
            };
            if(!Users.Any(x=>x.UserName == user.UserName))
            {
                Application.Current.Dispatcher.Invoke(() => Users.Add(user));
            }
        }
    }
}
