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
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private List<string> allTitles = new List<string>();
        private List<string> allArtists = new List<string>();
        private List<string> allAlbums = new List<string>();
        private List<string> allAdds = new List<string>();
        public SearchWindow()
        {
            InitializeComponent();
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
            Titles.ItemsSource = null;
            Artists.ItemsSource = null;
            Albums.ItemsSource = null;
            AddButtons.ItemsSource = null;
            allTitles.Clear();
            allAlbums.Clear();
            allArtists.Clear();
            allAdds.Clear();
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
    }
}
