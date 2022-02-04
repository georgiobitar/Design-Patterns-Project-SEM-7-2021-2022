using Flurl.Http;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;
using Infrastructure.Models;
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
using WebAPI.Structural;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for VerifyEmailSendCode.xaml
    /// </summary>
    public partial class VerifyEmailSendCode : Page
    {
        private readonly User user;

        public VerifyEmailSendCode()
        {
            InitializeComponent();
            this.user = Singleton.GetUser();
        }

        private async void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CodeTB.Text == user.Email)
            {
                SendEmailCodeRequestDTO sendEmailCodeRequestDTO = new SendEmailCodeRequestDTO() { User = user };
                SendEmailCodeResponseDTO response = await (ServiceEndpoints.Endpoint + "/Authentication/SendEmailCode").PostJsonAsync(sendEmailCodeRequestDTO).ReceiveJson<SendEmailCodeResponseDTO>();
                MessageBox.Show(response.Message);
                if (response.Success)
                {
                    NavigationService.Navigate(new VerifyEmailVerifyCode());
                }
            }
            else
            {
                MessageBox.Show("Wrong Email!");
            }
        }
    }
}
