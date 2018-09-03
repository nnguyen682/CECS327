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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var msg = "Incorrect Username or Password!";
            if (user.Text == "omponce" && pass.Password == "cecs327")
            {
                AfterLogin b = new AfterLogin();
                this.Close();
                b.Show();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var msg = "Incorrect Username or Password!";
                if (user.Text == "omponce" && pass.Password == "cecs327")
                {
                    AfterLogin b = new AfterLogin();
                    this.Close();
                    b.Show();
                }
                else
                {
                    MessageBox.Show(msg);
                }
            }
        }

        private void OnUserChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Tag != null)
            {
                textBox.Tag = (!String.IsNullOrWhiteSpace(textBox.Text)).ToString();
            }
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passBox = sender as PasswordBox;
            if (passBox.Tag != null)
            {
                passBox.Tag = (!String.IsNullOrWhiteSpace(passBox.Password)).ToString();
            }
        }
    }
}