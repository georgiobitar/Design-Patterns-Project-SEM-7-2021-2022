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
using WebAPI.Services;
using WebAPI.Structural;


namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for VerifyMobileSendCodePage.xaml
    /// </summary>
    public partial class VerifyMobileSendCodePage : Page
    {
        public readonly User user;

        public VerifyMobileSendCodePage()
        {
            InitializeComponent();
            this.user = Singleton.GetUser();
        }

        private async void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CodeTB.Text == user.PhoneNumber)
            {
                SendMobileCodeRequestDTO sendMobileCodeRequestDTO = new SendMobileCodeRequestDTO() { User = user};
                SendMobileCodeResponseDTO response = await (ServiceEndpoints.Endpoint + "/Authentication/SendMobileCode").PostJsonAsync(sendMobileCodeRequestDTO).ReceiveJson<SendMobileCodeResponseDTO>();
                MessageBox.Show(response.Message);
                if (response.Success)
                {
                    NavigationService.Navigate(new VerifyMobileVerifyCode());
                }
            }
            else
            {
                MessageBox.Show("Wrong Phone Number!");
            }
        }
    }
}
