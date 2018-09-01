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

        List<string> mediaFileList;
        string mediaFolder = Directory.GetCurrentDirectory();
        public AfterLogin()
        {
            InitializeComponent();
            mediaFileList = new List<string>();
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
  /*
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            mediaFileList = new List<string>();
            System.Windows.Forms.FolderBrowserDialog fbd = new
                System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                mediaFolder = fbd.SelectedPath;
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
        }
        */
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Profile b = new Profile();
            this.Close();
            b.Show();
        }
    }
}
