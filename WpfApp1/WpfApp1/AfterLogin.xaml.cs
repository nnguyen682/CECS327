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
using System.IO;
using WMPLib;
using AxWMPLib;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AfterLogin.xaml
    /// </summary>
    public partial class AfterLogin : Window
    {

        public static List<string> mediaFileList = new List<string>();
        public static string LameName;
        string mediaFolder = Directory.GetCurrentDirectory();
        public AfterLogin()
        {
            InitializeComponent();
            DirectoryInfo dir = new DirectoryInfo(mediaFolder);
            foreach (FileInfo file in dir.GetFiles("*.*", SearchOption.AllDirectories))
            {
                if (file.Extension == ".mp3" || file.Extension == ".mp4")
                    mediaFileList.Add(file.Name);
            }
            if (mediaFileList != null)
            {
                list.ItemsSource = null;
                list.ItemsSource = mediaFileList;
            }
        }
        
        public AfterLogin(string name)
        {
            InitializeComponent();
            username.Content = name;
            LameName = name;
            profile.Source = new BitmapImage(new Uri("pack://application:,,,/Images/"+ name+".png"));
            DirectoryInfo dir = new DirectoryInfo(mediaFolder);
            foreach (FileInfo file in dir.GetFiles("*.*", SearchOption.AllDirectories))
            {
                if (file.Extension == ".mp3" || file.Extension == ".mp4")
                    mediaFileList.Add(file.Name);
            }
            if (mediaFileList != null)
            {
                list.ItemsSource = null;
                list.ItemsSource = mediaFileList;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
                private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AxWMPLib.AxWindowsMediaPlayer ax=
                winsFormHost.Child as AxWMPLib.AxWindowsMediaPlayer;
            ax.URL = mediaFolder+ "\\" + list.SelectedItem.ToString();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Profile b = new Profile();
            this.Close();
            b.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginScreen b = new LoginScreen();
            mediaFileList.Clear();
            this.Close();
            b.Show();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
