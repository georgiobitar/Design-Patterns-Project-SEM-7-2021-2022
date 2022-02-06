using Flurl.Http;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Infrastructure.Model.enums;
using Infrastructure.Models;
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
using WebAPI.Exceptions;
using WebAPI.Handlers;
using WebAPI.Services;
using WebAPI.Structural;
using WPF.Pages;

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
            LoginRequestDTO loginRequest = new LoginRequestDTO() { UserName = UserNameTextBox.Text, Password = PasswordTextBox.Text };
            LoginResponseDTO response = await (ServiceEndpoints.Endpoint + "/Authentication/Login").PostJsonAsync(loginRequest).ReceiveJson<LoginResponseDTO>(); //using Flurl
            MessageBox.Show(response.Message);
            if (response.Success)
            {
                try
                {
                    var handler = new PhoneNumberVerifiedHandler();

                    handler.SetNext(new EmailVerifiedHandler());
                    handler.Handle(response.User);
                    Singleton.SetUser(response.User); //Caching the User

                    switch (handler.Status)
                    {
                        case NextPageStatus.VerifyMobileNumber:
                            VerifyMobileNumberPage v = new VerifyMobileNumberPage();
                            v.Show();
                            this.Close();
                            break;

                        case NextPageStatus.VerifyEmail:
                            VerifyEmailPage ve = new VerifyEmailPage();
                            ve.Show();
                            this.Close();
                            break;
                        default:
                            MainPage mp = new MainPage();
                            mp.Show();
                            this.Close();
                            break;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error occured");
                }
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
