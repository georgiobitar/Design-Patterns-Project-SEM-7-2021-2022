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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
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

            //Notifier notifier = new Notifier(cfg =>
            //{
            //    cfg.PositionProvider = new WindowPositionProvider(
            //        parentWindow: Application.Current.MainWindow,
            //        corner: Corner.TopRight,
            //        offsetX: 10,
            //        offsetY: 10);

            //    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            //        notificationLifetime: TimeSpan.FromSeconds(3),
            //        maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            //    cfg.Dispatcher = Application.Current.Dispatcher;
            //});
            //add it to singleton
            //call it when needed
            //dont forget to update it on each page :)
        }


        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (Valid())
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
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured");
                    }
                }
            }

        }

        private bool Valid()
        {
            if (UserNameTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return false;
            }
            else
                return true;
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage su = new SignUpPage();
            su.Show();
            this.Close();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonMaxmize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState != WindowState.Maximized ? WindowState.Maximized : WindowState.Normal;
        }
    }
}
