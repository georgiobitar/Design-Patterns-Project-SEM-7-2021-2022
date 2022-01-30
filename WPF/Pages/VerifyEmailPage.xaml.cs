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
using System.Windows.Shapes;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for VerifyEmailPage.xaml
    /// </summary>
    public partial class VerifyEmailPage : Window
    {
        private readonly User user;

        public VerifyEmailPage(User user)
        {
            InitializeComponent();
            this.user = user;
            VerifyEmailFrame.NavigationService.Navigate(new VerifyEmailSendCode(this.user));

        }
    }
}
