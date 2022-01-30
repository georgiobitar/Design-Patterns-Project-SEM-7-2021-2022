using Flurl.Http;
using Infrastructure.Model.enums;
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
using WebAPI.Handlers;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for VerifyMobileVerifyCode.xaml
    /// </summary>
    public partial class VerifyMobileVerifyCode : Page
    {
        private readonly User user;

        public VerifyMobileVerifyCode(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private async void VerifyCodeButton_Click(object sender, RoutedEventArgs e)
        {
            VerifyMobileCodeRequestDTO verifyMobileCodeRequestDTO = new VerifyMobileCodeRequestDTO() { Username = user.UserName, MobileCode = CodeTB.Text };
            VerifyMobileCodeResponseDTO response = await (ServiceEndpoints.Endpoint + "/Authentication/VerifyMobileCode").PostJsonAsync(verifyMobileCodeRequestDTO).ReceiveJson<VerifyMobileCodeResponseDTO>();
            MessageBox.Show(response.Message);
            if (response.Success)
            {
                try
                {
                    var handler = new PhoneNumberVerifiedHandler();

                    handler.SetNext(new EmailVerifiedHandler());
                    handler.Handle(response.User);

                    switch (handler.Status)
                    {
                        case NextPageStatus.VerifyMobileNumber:
                            App.Current.Windows[0].Close();
                            VerifyMobileNumberPage v = new VerifyMobileNumberPage(response.User);
                            v.Show();
                            break;

                        case NextPageStatus.VerifyEmail:
                            App.Current.Windows[0].Close();
                            VerifyEmailPage ve = new VerifyEmailPage(response.User);
                            ve.Show();
                            break;
                        default:
                            App.Current.Windows[0].Close();
                            MainPage mp = new MainPage(response.User);
                            mp.Show();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured");
                }
            }
        }
    }
}
