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
using WebAPI.Structural;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for VerifyEmailVerifyCode.xaml
    /// </summary>
    public partial class VerifyEmailVerifyCode : Page
    {
        private readonly User user;

        public VerifyEmailVerifyCode()
        {
            InitializeComponent();
            this.user = Singleton.GetUser();
        }

        private async void VerifyCodeButton_Click(object sender, RoutedEventArgs e)
        {
            VerifyEmailCodeRequestDTO verifyemailCodeRequestDTO = new VerifyEmailCodeRequestDTO() { Username = user.UserName, EmailCode = CodeTB.Text };
            VerifyEmailCodeResponseDTO response = await (ServiceEndpoints.Endpoint + "/Authentication/VerifyEmailCode").PostJsonAsync(verifyemailCodeRequestDTO).ReceiveJson<VerifyEmailCodeResponseDTO>();
            MessageBox.Show(response.Message);
            if (response.Success)
            {
                try
                {
                    Singleton.SetUser(response.User);
                    var handler = new PhoneNumberVerifiedHandler();
                    handler.SetNext(new EmailVerifiedHandler());
                    handler.Handle(response.User);

                    switch (handler.Status)
                    {
                        case NextPageStatus.VerifyMobileNumber:
                            VerifyMobileNumberPage v = new VerifyMobileNumberPage();
                            v.Show();
                            App.Current.Windows[0].Close();
                            break;

                        case NextPageStatus.VerifyEmail:
                            VerifyEmailPage ve = new VerifyEmailPage();
                            ve.Show();
                            App.Current.Windows[0].Close();
                            break;
                        default:
                            MainPage mp = new MainPage();
                            mp.Show();
                            App.Current.Windows[0].Close();
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
