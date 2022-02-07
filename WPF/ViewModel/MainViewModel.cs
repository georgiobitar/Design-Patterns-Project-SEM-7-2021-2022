using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatServer.Behavioral;
using WPF.Core;

namespace WPF.ViewModel
{
    public class MainViewModel
    {
        public RelayCommand ConnectToServerCommand { get; set; }
        public string  Username { get; set; }
        private Server server;
        public MainViewModel()
        {
            this.server = new Server();
            ConnectToServerCommand = new RelayCommand(o => this.server.ConnectToServer(Username), o => !string.IsNullOrEmpty(Username));
        }
    }
}
