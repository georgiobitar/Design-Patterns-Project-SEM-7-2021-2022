﻿using Infrastructure.Models;
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
    /// Interaction logic for VerifyMobileNumberPage.xaml
    /// </summary>
    public partial class VerifyMobileNumberPage : Window
    {
        private readonly User user;

        public VerifyMobileNumberPage(User user)
        {
            InitializeComponent();
            this.user = user;
            VerifyMobileFrame.NavigationService.Navigate(new VerifyMobileSendCodePage(this.user));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
