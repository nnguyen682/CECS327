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
    /// Interaction logic for Adding.xaml
    /// </summary>
    public partial class Adding : Window
    {
        public static Playlist currentPlayList;
        public static Window AddingWindow;
        public Adding()
        {
            InitializeComponent();
            //aList.ItemsSource = AfterLogin.mediaFileList;
            listTitle.Content =   Create.selectedList.ToString();
            currentPlayList = AfterLogin.objectUser.mPlaylists.Where(x => x.mName == Create.selectedList.ToString()).Single();
            foreach (var b in currentPlayList.mSongs)
            {
                ListBoxItem itm = new ListBoxItem();
                string trythis = b.mArtist + "-" + b.mTitle + b.mExtension;
                itm.Content = trythis;
                addedSongs.Items.Add(itm);
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            Create.createWIndow.Show();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /*
        private void Button_Add(object sender, RoutedEventArgs e)
        {

            if (aList.SelectedItem != null)
            {
                ListBoxItem itm = new ListBoxItem();
                string trythis = (string)aList.SelectedValue;
                itm.Content = trythis;
                
                if (currentPlayList.mSongs.FirstOrDefault(x => (x.mArtist + "-" + x.mTitle + x.mExtension) == trythis) == null)
                {
                    currentPlayList.addSong(LoginScreen.allSongs.mSongs.Where(x => (x.mArtist + "-" + x.mTitle + x.mExtension) == trythis).Single());
                    addedSongs.Items.Add(itm);
                }
                else
                    MessageBox.Show("Selected song is already added in the playlist");
            }
            
        }
        */

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var msg = "No song was selected to delete";
            
            
            if (addedSongs.SelectedItem != null)
            {
                string b = ((ListBoxItem)addedSongs.SelectedItem).Content.ToString();
                addedSongs.Items.Remove(addedSongs.SelectedItem);
                AfterLogin.objectUser.mPlaylists.Where(x => x.mName == currentPlayList.mName).Single().deleteSong(AfterLogin.objectUser.mPlaylists.Where(x => x.mName == currentPlayList.mName).Single().mSongs.Where(x => x.mArtist + '-' + x.mTitle + x.mExtension == b).Single());
            }
            else
                MessageBox.Show(msg);
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

        private void addedSongs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow = this;
            SearchWindow sW = new SearchWindow();
            this.Hide();
            sW.Show();
        }
    }
}