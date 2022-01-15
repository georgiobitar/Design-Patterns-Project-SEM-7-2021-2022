using Infrastructure;
using Infrastructure.Model.DataContracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    public partial class LoginPage : Window
    {
        
        public LoginPage()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            //HttpClient httpClient = new HttpClient();
            //LoginResponseDTO response = httpClient.GetFromJsonAsync<LoginResponseDTO>(requestUri: "");// new User() { UserName = UserNameTextBox.Text, Password = PasswordTextBox.Text });
            
            SignUpPage su = new SignUpPage();
            su.Show();
            this.Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
