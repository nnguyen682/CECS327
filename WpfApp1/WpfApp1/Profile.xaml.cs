﻿using System;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            // passing the user picture
            profile.Source = new BitmapImage(new Uri("pack://application:,,,/Images/" + AfterLogin.objectUser.mUsername + ".png"));
            name.Content = AfterLogin.objectUser.mName;
            email.Content = AfterLogin.objectUser.mEmail;
            Birthday.Content = AfterLogin.objectUser.mBirthday;
        }

        private void Button_Back(object sender, RoutedEventArgs e)// going back to the login screen
        {
            this.Hide();
            AfterLogin.afterLoginWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) //override the x button
        {
            if (!LoginScreen.LoginWindow.closingFlag)
            {
                LoginScreen.LoginWindow.ConfirmExit();
            }
            if (LoginScreen.LoginWindow.closingFlag)
            {
                App.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
