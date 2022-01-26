using Flurl.Http;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Newtonsoft.Json;
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
using WebAPI.Services;

namespace WPF
{
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            LoginRequestDTO loginRequest = new LoginRequestDTO() { UserName = UserNameTextBox.Text, Password = PasswordTextBox.Text };
            LoginResponseDTO response = await "https://localhost:7004/Authentication".PostJsonAsync(loginRequest).ReceiveJson<LoginResponseDTO>();
            MessageBox.Show(response.Message);
            if (response.Success)
            {
                MainPage mp = new MainPage();
                mp.Show();
                this.Close();
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage su = new SignUpPage();
            su.Show();
            this.Close();
        }
    }
}
