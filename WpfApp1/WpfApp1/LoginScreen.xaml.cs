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
        public static Window LoginWindow;
        static IList<User> allUsers = new List<User>();
        static Playlist nhanList;
        static Playlist ponceList = new Playlist("ponceList");
        static Song BangBangBang = new Song("BangBangBang", "BigBang", ".mp3");
        static Song Baam = new Song("Baam", "MoMoLand", ".mp3");
        static Song LaTaTa = new Song("LaTaTa", "(G)I-DLE", ".mp3");
        public LoginScreen()
        {
            InitializeComponent();
            allUsers.Add(new User("nnguyen682", "nhannguyen1", "Nhan Nguyen", "nhannguyen683@gmail.com", "03/07/1994"));
            allUsers.Add(new User("omponce", "cecs327", "Om Ponce", "OmPonce@gmail.com", "03/17/1974"));
            nhanList = new Playlist("nhanList");
            nhanList.addSong(BangBangBang);
            nhanList.addSong(Baam);
            ponceList.addSong(LaTaTa);
            allUsers.Where(x => x.mUsername == "nnguyen682").Single().mPlaylists.Add(nhanList);
            allUsers.Where(x => x.mUsername == "omponce").Single().mPlaylists.Add(ponceList);
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            var msg = "Incorrect Username or Password!";
            foreach(var x in allUsers)
            {
                
                if(user.Text == x.mUsername && pass.Password == x.mPassword)
                {
                    AfterLogin b = new AfterLogin(x);
                    counter++;
                    LoginWindow = this;
                    user.Text = "";
                    pass.Password = "";
                    this.Hide();
                    b.Show();
                    break;
                }
                
            }
            if (counter == 0)
            {
                MessageBox.Show(msg);
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var msg = "Incorrect Username or Password!";
                int counter = 0;
                foreach (var x in allUsers)
                {
                    
                    if (user.Text == x.mUsername && pass.Password == x.mPassword)
                    {
                        AfterLogin b = new AfterLogin(x);
                        counter++;
                        LoginWindow = this;
                        user.Text = "";
                        pass.Password = "";
                        this.Hide();
                        b.Show();
                        break;
                    }

                }

                if (counter == 0)
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