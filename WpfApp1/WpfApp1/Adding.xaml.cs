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
        public Adding()
        {
            InitializeComponent();
            aList.ItemsSource = AfterLogin.mediaFileList;
            listTitle.Content =   Create.selectedList.ToString();
            currentPlayList = AfterLogin.objectUser.mPlaylists.Where(x => x.mName == Create.selectedList.ToString()).Single();
            foreach (var b in currentPlayList.mSongs)
                addedSongs.Items.Add(b.mArtist + "-" +b.mTitle + b.mExtension);
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            Create.createWIndow.Show();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

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
        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var msg = "No song was selected to delete";

            string b = (string) addedSongs.SelectedItem;
            if (addedSongs.SelectedItem != null)
            {
                addedSongs.Items.Remove(addedSongs.SelectedItem);
                AfterLogin.objectUser.mPlaylists.Where(x => x.mName == currentPlayList.mName).Single().deleteSong(AfterLogin.objectUser.mPlaylists.Where(x => x.mName == currentPlayList.mName).Single().mSongs.Where(x => x.mArtist + '-' + x.mTitle + x.mExtension == b).Single());
            }
            else
                MessageBox.Show(msg);
        }
    }
}
