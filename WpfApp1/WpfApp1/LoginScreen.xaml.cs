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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var msg = "Incorrect Username or Password!";
            if (user.Text == "cigarAsh" && pass.Password == "nhannguyen1") {
                Profile b = new Profile();
                this.Close();
                b.Show();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key ==Key.Enter)
            {
                var msg = "Incorrect Username or Password!";
                if (user.Text == "cigarAsh" && pass.Password == "nhannguyen1")
                {
                    Profile b = new Profile();
                    this.Close();
                    b.Show();
                }
                else
                {
                    MessageBox.Show(msg);
                }
            }
        }
    }
}
