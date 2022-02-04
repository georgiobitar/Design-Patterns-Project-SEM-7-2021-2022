using Flurl.Http;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class SignUpPage : Window
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            SignUpRequestDTO signUpRequest = new SignUpRequestDTO()
            {
                UserName = UserNameTB.Text,
                FirstName = FirstNameTB.Text,
                LastName = LastNameTB.Text,
                Email = EmailTB.Text,
                PhoneNumber = MobileTB.Text,
                Country = CountryTB.Text,
                Password = PasswordTB.Text
            };
            SignUpResponseDTO response = await (ServiceEndpoints.Endpoint + "/Authentication/SignUp").PostJsonAsync(signUpRequest).ReceiveJson<SignUpResponseDTO>();
            MessageBox.Show(response.Message);
            if(response.Success)
            {
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Close();
            }


        }
    }
}
