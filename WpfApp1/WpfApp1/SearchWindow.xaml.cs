using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

using System.Windows.Controls;
using System.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private List<string> allTitles = new List<string>();
        private List<string> allArtists = new List<string>();
        private List<string> allAlbums = new List<string>();
        private List<string> allAdds = new List<string>();
        private Playlist currentPlayList;
        public SearchWindow()
        {
            InitializeComponent();
            //listTitle.Content = "Adding to " + Create.selectedList.ToString() + "playlist";
            currentPlayList = AfterLogin.objectUser.mPlaylists.Where(x => x.mName == Create.selectedList.ToString()).Single();
            foreach (Song x in LoginScreen.allSongs.mSongs)
            {
                allTitles.Add(x.mTitle);
                allArtists.Add(x.mArtist);
                allAlbums.Add(x.mAlbum);
                allAdds.Add("Choose Playlist");
            }
            Titles.ItemsSource = allTitles;
            Artists.ItemsSource = allArtists;
            Albums.ItemsSource = allAlbums;
            AddButtons.ItemsSource = allAdds;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            string searchVal = SearchText.Text;
            if (SearchBy.SelectedIndex == 0)
            {
                foreach(Song x in LoginScreen.allSongs.mSongs)
                {
                    if (x.mTitle.ToLower().Contains(searchVal.ToLower()))
                    {
                        allTitles.Add(x.mTitle);
                        allArtists.Add(x.mArtist);
                        allAlbums.Add(x.mAlbum);
                        allAdds.Add("Choose Playlist");
                    }
                }
            }
            else if (SearchBy.SelectedIndex == 1)
            {
                foreach (Song x in LoginScreen.allSongs.mSongs)
                {
                    if (x.mArtist.ToLower().Contains(searchVal.ToLower()))
                    {
                        allTitles.Add(x.mTitle);
                        allArtists.Add(x.mArtist);
                        allAlbums.Add(x.mAlbum);
                        allAdds.Add("Choose Playlist");
                    }
                }
            }
            else if (SearchBy.SelectedIndex == 2)
            {
                foreach (Song x in LoginScreen.allSongs.mSongs)
                {
                    if (x.mAlbum.ToLower().Contains(searchVal.ToLower()))
                    {
                        allTitles.Add(x.mTitle);
                        allArtists.Add(x.mArtist);
                        allAlbums.Add(x.mAlbum);
                        allAdds.Add("Choose Playlist");
                    }
                }
            }
            Titles.ItemsSource = allTitles;
            Artists.ItemsSource = allArtists;
            Albums.ItemsSource = allAlbums;
            AddButtons.ItemsSource = allAdds;
        }

        private void ComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Reset();
                string searchVal = SearchText.Text;
                if (SearchBy.SelectedIndex == 0)
                {
                    foreach (Song x in LoginScreen.allSongs.mSongs)
                    {
                        if (x.mTitle.ToLower().Contains(searchVal.ToLower()))
                        {
                            allTitles.Add(x.mTitle);
                            allArtists.Add(x.mArtist);
                            allAlbums.Add(x.mAlbum);
                            allAdds.Add("Choose Playlist");
                        }
                    }
                }
                else if (SearchBy.SelectedIndex == 1)
                {
                    foreach (Song x in LoginScreen.allSongs.mSongs)
                    {
                        if (x.mArtist.ToLower().Contains(searchVal.ToLower()))
                        {
                            allTitles.Add(x.mTitle);
                            allArtists.Add(x.mArtist);
                            allAlbums.Add(x.mAlbum);
                            allAdds.Add("Choose Playlist");
                        }
                    }
                }
                else if (SearchBy.SelectedIndex == 2)
                {
                    foreach (Song x in LoginScreen.allSongs.mSongs)
                    {
                        if (x.mAlbum.ToLower().Contains(searchVal.ToLower()))
                        {
                            allTitles.Add(x.mTitle);
                            allArtists.Add(x.mArtist);
                            allAlbums.Add(x.mAlbum);
                            allAdds.Add("Choose Playlist");
                        }
                    }
                }
                Titles.ItemsSource = allTitles;
                Artists.ItemsSource = allArtists;
                Albums.ItemsSource = allAlbums;
                AddButtons.ItemsSource = allAdds;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            List<string> temp = new List<string>();
            foreach (var b in Adding.currentPlayList.mSongs)
                temp.Add(b.mArtist + "-" + b.mTitle + b.mExtension);
            AfterLogin.ListofListBox.Where(x => x.Name == Adding.currentPlayList.mName).Single().ItemsSource = temp;
            SearchText.Text = "";
            Reset();
            this.Hide();
            Adding.AddingWindow.Show();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(Titles.SelectedItem != null)
            {
                ListBoxItem itm = new ListBoxItem();

                Song b = LoginScreen.allSongs.mSongs.Where(x => x.mTitle == (string)Titles.SelectedValue).Single();
                string trythis = b.mArtist + "-" + b.mTitle + b.mExtension;
                
         
                if (Adding.currentPlayList.mSongs.FirstOrDefault(x => (x.mArtist + "-" + x.mTitle + x.mExtension) == trythis) == null)
                {  
                    Adding.currentPlayList.addSong(LoginScreen.allSongs.mSongs.Where(x => (x.mArtist + "-" + x.mTitle + x.mExtension) == trythis).Single());
                }
                else
                    MessageBox.Show("Selected song is already added in the playlist");
            }


        }

        private void Reset()
        {
            Titles.ItemsSource = null;
            Artists.ItemsSource = null;
            Albums.ItemsSource = null;
            AddButtons.ItemsSource = null;
            allTitles.Clear();
            allAlbums.Clear();
            allArtists.Clear();
            allAdds.Clear();
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

        private void Titles_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
