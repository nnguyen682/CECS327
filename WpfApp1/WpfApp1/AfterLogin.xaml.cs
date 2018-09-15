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
using System.IO;
using WMPLib;
using AxWMPLib;
using System.Windows.Forms;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AfterLogin.xaml
    /// </summary>
    public partial class AfterLogin : Window
    {

        public static List<string> mediaFileList;
        public static User objectUser;
        public static Window afterLoginWindow;
        public static AxWMPLib.AxWindowsMediaPlayer ax;
        public static StackPanel AllPLaylist;
        string mediaFolder = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "MusicLibrary");
      

        public AfterLogin(User x)
        {
           
            
            var newBox = new System.Windows.Controls.ListBox();
            objectUser = new User();
            mediaFileList = new List<string>();
            InitializeComponent();
            username.Content = x.mUsername;
            ax =
                winsFormHost.Child as AxWMPLib.AxWindowsMediaPlayer;
            objectUser = x;
            profile.Source = new BitmapImage(new Uri("pack://application:,,,/Images/" + x.mUsername + ".png"));
            
            DirectoryInfo dir = new DirectoryInfo(mediaFolder);

            foreach (FileInfo file in dir.GetFiles("*.*", SearchOption.AllDirectories))
            {
                if (file.Extension == ".mp3" || file.Extension == ".mp4")
                    mediaFileList.Add(file.Name);
            }
            if (mediaFileList != null)
            {
                newBox.ItemsSource = mediaFileList;
                ax.URL = mediaFolder + "\\" + mediaFileList[0];
            }
            var newstackPanel = new StackPanel { Name = "NewExpanderStackPanel" };
            newstackPanel.Children.Add(newBox);
            Expander exp = new Expander();
            exp.Content = newstackPanel;
            allPlaylist.Children.Add(exp);
            newBox.Background = Brushes.Black;
            newBox.Foreground = Brushes.LightGray;
            foreach (var b in objectUser.mPlaylists)
            {
                Expander exp1 = new Expander();
                var newStack = new StackPanel { Name = "NewExpanderStackPanel" };
                var newListBox = new System.Windows.Controls.ListBox();
                newListBox.Background = Brushes.Black;
                newListBox.Foreground = Brushes.White;
                var newMediaFileList = new List<string>();
                foreach (var d in b.mSongs)
                    newMediaFileList.Add(d.mArtist + "-" + d.mTitle + d.mExtension);
                newListBox.ItemsSource = newMediaFileList;
                newStack.Children.Add(newListBox);
                exp1.Content = newStack;
                exp1.Header = b.mName;
                
                allPlaylist.Children.Add(exp1);

            }
            AllPLaylist = allPlaylist;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems[0] !=null)
               ax.URL = mediaFolder + "\\" + e.AddedItems[0];
        }

        private void Button_Profile(object sender, RoutedEventArgs e)
        {
            afterLoginWindow = this;
            Profile b = new Profile();
            this.Hide();
            b.Show();
        }

        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            ax.close();
            mediaFileList.Clear();
            this.Hide();
            LoginScreen.LoginWindow.Show();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void OpenAddingPlayList(object sender, RoutedEventArgs e)
        {
            afterLoginWindow = this;
            Create b = new Create();
            this.Hide();
            b.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        /**
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow sW = new SearchWindow();
            this.Hide();
            sW.Show();
        }*/
    }
}
