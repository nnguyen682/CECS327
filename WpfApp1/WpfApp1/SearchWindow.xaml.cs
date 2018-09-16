﻿using System.Collections.Generic;
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
        private List<Panel> songObjs = new List<Panel>();
        private Playlist currentPlayList;
        private List<string> songStr = new List<string>();
        public SearchWindow()
        {
            InitializeComponent();
            //listTitle.Content = "Adding to " + Create.selectedList.ToString() + "playlist";
            
            currentPlayList = AfterLogin.objectUser.mPlaylists.Where(x => x.mName == Create.selectedList.ToString()).Single();
            PlaylistName.Content = "Adding songs to: " + currentPlayList.mName + " (select a song and click add)";
            foreach (Song x in LoginScreen.allSongs.mSongs)
            {
                StackPanel sP = new StackPanel();
                sP.Orientation = Orientation.Horizontal;
                Label titleLbl = new Label();
                Label artistLbl = new Label();
                Label albumLbl = new Label();
                Label extensionLbl = new Label();
                titleLbl.Content = " Song Title: ";
                artistLbl.Content = " Artist(s): ";
                albumLbl.Content = " Album: ";
                extensionLbl.Content = " File Type: ";
                titleLbl.FontWeight = FontWeights.Bold;
                artistLbl.FontWeight = FontWeights.Bold;
                albumLbl.FontWeight = FontWeights.Bold;
                extensionLbl.FontWeight = FontWeights.Bold;
                Label dspTitle = new Label();
                Label dspArtist = new Label();
                Label dspAlbum = new Label();
                Label dspExtension = new Label();
                dspTitle.Content = x.mTitle;
                dspArtist.Content = x.mArtist;
                dspAlbum.Content = x.mAlbum;
                dspExtension.Content = x.mExtension;
                sP.Children.Add(titleLbl);
                sP.Children.Add(dspTitle);
                sP.Children.Add(artistLbl);
                sP.Children.Add(dspArtist);
                sP.Children.Add(albumLbl);
                sP.Children.Add(dspAlbum);
                sP.Children.Add(extensionLbl);
                sP.Children.Add(dspExtension);
                songObjs.Add(sP);
                songStr.Add(" Song Title: " + x.mTitle + " Artist(s): " + x.mArtist + " Album: " + x.mAlbum + " File Type: " + x.mExtension);

            }
            Titles.ItemsSource = songObjs;
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
                        StackPanel sP = new StackPanel();
                        sP.Orientation = Orientation.Horizontal;
                        Label titleLbl = new Label();
                        Label artistLbl = new Label();
                        Label albumLbl = new Label();
                        Label extensionLbl = new Label();
                        titleLbl.Content = " Song Title: ";
                        artistLbl.Content = " Artist(s): ";
                        albumLbl.Content = " Album: ";
                        extensionLbl.Content = " File Type: ";
                        titleLbl.FontWeight = FontWeights.Bold;
                        artistLbl.FontWeight = FontWeights.Bold;
                        albumLbl.FontWeight = FontWeights.Bold;
                        extensionLbl.FontWeight = FontWeights.Bold;
                        Label dspTitle = new Label();
                        Label dspArtist = new Label();
                        Label dspAlbum = new Label();
                        Label dspExtension = new Label();
                        dspTitle.Content = x.mTitle;
                        dspArtist.Content = x.mArtist;
                        dspAlbum.Content = x.mAlbum;
                        dspExtension.Content = x.mExtension;
                        sP.Children.Add(titleLbl);
                        sP.Children.Add(dspTitle);
                        sP.Children.Add(artistLbl);
                        sP.Children.Add(dspArtist);
                        sP.Children.Add(albumLbl);
                        sP.Children.Add(dspAlbum);
                        sP.Children.Add(extensionLbl);
                        sP.Children.Add(dspExtension);
                        songObjs.Add(sP);
                        songStr.Add(" Song Title: " + x.mTitle + " Artist(s): " + x.mArtist + " Album: " + x.mAlbum + " File Type: " + x.mExtension);
                    }
                }
            }
            else if (SearchBy.SelectedIndex == 1)
            {
                foreach (Song x in LoginScreen.allSongs.mSongs)
                {
                    if (x.mArtist.ToLower().Contains(searchVal.ToLower()))
                    {
                        StackPanel sP = new StackPanel();
                        sP.Orientation = Orientation.Horizontal;
                        Label titleLbl = new Label();
                        Label artistLbl = new Label();
                        Label albumLbl = new Label();
                        Label extensionLbl = new Label();
                        titleLbl.Content = " Song Title: ";
                        artistLbl.Content = " Artist(s): ";
                        albumLbl.Content = " Album: ";
                        extensionLbl.Content = " File Type: ";
                        titleLbl.FontWeight = FontWeights.Bold;
                        artistLbl.FontWeight = FontWeights.Bold;
                        albumLbl.FontWeight = FontWeights.Bold;
                        extensionLbl.FontWeight = FontWeights.Bold;
                        Label dspTitle = new Label();
                        Label dspArtist = new Label();
                        Label dspAlbum = new Label();
                        Label dspExtension = new Label();
                        dspTitle.Content = x.mTitle;
                        dspArtist.Content = x.mArtist;
                        dspAlbum.Content = x.mAlbum;
                        dspExtension.Content = x.mExtension;
                        sP.Children.Add(titleLbl);
                        sP.Children.Add(dspTitle);
                        sP.Children.Add(artistLbl);
                        sP.Children.Add(dspArtist);
                        sP.Children.Add(albumLbl);
                        sP.Children.Add(dspAlbum);
                        sP.Children.Add(extensionLbl);
                        sP.Children.Add(dspExtension);
                        songObjs.Add(sP);
                        songStr.Add(" Song Title: " + x.mTitle + " Artist(s): " + x.mArtist + " Album: " + x.mAlbum + " File Type: " + x.mExtension);
                    }
                }
            }
            else if (SearchBy.SelectedIndex == 2)
            {
                foreach (Song x in LoginScreen.allSongs.mSongs)
                {
                    if (x.mAlbum.ToLower().Contains(searchVal.ToLower()))
                    {
                        StackPanel sP = new StackPanel();
                        sP.Orientation = Orientation.Horizontal;
                        Label titleLbl = new Label();
                        Label artistLbl = new Label();
                        Label albumLbl = new Label();
                        Label extensionLbl = new Label();
                        titleLbl.Content = " Song Title: ";
                        artistLbl.Content = " Artist(s): ";
                        albumLbl.Content = " Album: ";
                        extensionLbl.Content = " File Type: ";
                        titleLbl.FontWeight = FontWeights.Bold;
                        artistLbl.FontWeight = FontWeights.Bold;
                        albumLbl.FontWeight = FontWeights.Bold;
                        extensionLbl.FontWeight = FontWeights.Bold;
                        Label dspTitle = new Label();
                        Label dspArtist = new Label();
                        Label dspAlbum = new Label();
                        Label dspExtension = new Label();
                        dspTitle.Content = x.mTitle;
                        dspArtist.Content = x.mArtist;
                        dspAlbum.Content = x.mAlbum;
                        dspExtension.Content = x.mExtension;
                        sP.Children.Add(titleLbl);
                        sP.Children.Add(dspTitle);
                        sP.Children.Add(artistLbl);
                        sP.Children.Add(dspArtist);
                        sP.Children.Add(albumLbl);
                        sP.Children.Add(dspAlbum);
                        sP.Children.Add(extensionLbl);
                        sP.Children.Add(dspExtension);
                        songObjs.Add(sP);
                        songStr.Add(" Song Title: " + x.mTitle + " Artist(s): " + x.mArtist + " Album: " + x.mAlbum + " File Type: " + x.mExtension);

                    }
                }
            }
            if (songObjs.Count != 0)
            {
                Titles.ItemsSource = songObjs;
            }
            else
            {
                Titles.ItemsSource = "No results found :(";
            }
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
                            StackPanel sP = new StackPanel();
                            sP.Orientation = Orientation.Horizontal;
                            Label titleLbl = new Label();
                            Label artistLbl = new Label();
                            Label albumLbl = new Label();
                            Label extensionLbl = new Label();
                            titleLbl.Content = " Song Title: ";
                            artistLbl.Content = " Artist(s): ";
                            albumLbl.Content = " Album: ";
                            extensionLbl.Content = " File Type: ";
                            titleLbl.FontWeight = FontWeights.Bold;
                            artistLbl.FontWeight = FontWeights.Bold;
                            albumLbl.FontWeight = FontWeights.Bold;
                            extensionLbl.FontWeight = FontWeights.Bold;
                            Label dspTitle = new Label();
                            Label dspArtist = new Label();
                            Label dspAlbum = new Label();
                            Label dspExtension = new Label();
                            dspTitle.Content = x.mTitle;
                            dspArtist.Content = x.mArtist;
                            dspAlbum.Content = x.mAlbum;
                            dspExtension.Content = x.mExtension;
                            sP.Children.Add(titleLbl);
                            sP.Children.Add(dspTitle);
                            sP.Children.Add(artistLbl);
                            sP.Children.Add(dspArtist);
                            sP.Children.Add(albumLbl);
                            sP.Children.Add(dspAlbum);
                            sP.Children.Add(extensionLbl);
                            sP.Children.Add(dspExtension);
                            songObjs.Add(sP);
                            songStr.Add(" Song Title: " + x.mTitle + " Artist(s): " + x.mArtist + " Album: " + x.mAlbum + " File Type: " + x.mExtension);

                        }
                    }
                }
                else if (SearchBy.SelectedIndex == 1)
                {
                    foreach (Song x in LoginScreen.allSongs.mSongs)
                    {
                        if (x.mArtist.ToLower().Contains(searchVal.ToLower()))
                        {
                            StackPanel sP = new StackPanel();
                            sP.Orientation = Orientation.Horizontal;
                            Label titleLbl = new Label();
                            Label artistLbl = new Label();
                            Label albumLbl = new Label();
                            Label extensionLbl = new Label();
                            titleLbl.Content = " Song Title: ";
                            artistLbl.Content = " Artist(s): ";
                            albumLbl.Content = " Album: ";
                            extensionLbl.Content = " File Type: ";
                            titleLbl.FontWeight = FontWeights.Bold;
                            artistLbl.FontWeight = FontWeights.Bold;
                            albumLbl.FontWeight = FontWeights.Bold;
                            extensionLbl.FontWeight = FontWeights.Bold;
                            Label dspTitle = new Label();
                            Label dspArtist = new Label();
                            Label dspAlbum = new Label();
                            Label dspExtension = new Label();
                            dspTitle.Content = x.mTitle;
                            dspArtist.Content = x.mArtist;
                            dspAlbum.Content = x.mAlbum;
                            dspExtension.Content = x.mExtension;
                            sP.Children.Add(titleLbl);
                            sP.Children.Add(dspTitle);
                            sP.Children.Add(artistLbl);
                            sP.Children.Add(dspArtist);
                            sP.Children.Add(albumLbl);
                            sP.Children.Add(dspAlbum);
                            sP.Children.Add(extensionLbl);
                            sP.Children.Add(dspExtension);
                            songObjs.Add(sP);
                            songStr.Add(" Song Title: " + x.mTitle + " Artist(s): " + x.mArtist + " Album: " + x.mAlbum + " File Type: " + x.mExtension);

                        }
                    }
                }
                else if (SearchBy.SelectedIndex == 2)
                {
                    foreach (Song x in LoginScreen.allSongs.mSongs)
                    {
                        if (x.mAlbum.ToLower().Contains(searchVal.ToLower()))
                        {
                            StackPanel sP = new StackPanel();
                            sP.Orientation = Orientation.Horizontal;
                            Label titleLbl = new Label();
                            Label artistLbl = new Label();
                            Label albumLbl = new Label();
                            Label extensionLbl = new Label();
                            titleLbl.Content = " Song Title: ";
                            artistLbl.Content = " Artist(s): ";
                            albumLbl.Content = " Album: ";
                            extensionLbl.Content = " File Type: ";
                            titleLbl.FontWeight = FontWeights.Bold;
                            artistLbl.FontWeight = FontWeights.Bold;
                            albumLbl.FontWeight = FontWeights.Bold;
                            extensionLbl.FontWeight = FontWeights.Bold;
                            Label dspTitle = new Label();
                            Label dspArtist = new Label();
                            Label dspAlbum = new Label();
                            Label dspExtension = new Label();
                            dspTitle.Content = x.mTitle;
                            dspArtist.Content = x.mArtist;
                            dspAlbum.Content = x.mAlbum;
                            dspExtension.Content = x.mExtension;
                            sP.Children.Add(titleLbl);
                            sP.Children.Add(dspTitle);
                            sP.Children.Add(artistLbl);
                            sP.Children.Add(dspArtist);
                            sP.Children.Add(albumLbl);
                            sP.Children.Add(dspAlbum);
                            sP.Children.Add(extensionLbl);
                            sP.Children.Add(dspExtension);
                            songObjs.Add(sP);
                            songStr.Add(" Song Title: " + x.mTitle + " Artist(s): " + x.mArtist + " Album: " + x.mAlbum + " File Type: " + x.mExtension);

                        }
                    }
                }
                if (songObjs.Count != 0)
                {
                    Titles.ItemsSource = songObjs;
                }
                else
                {
                    Titles.ItemsSource = "No results found :(";
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
            
            SearchText.Text = "";
            Reset();
            this.Hide();
            Adding.AddingWindow.Show();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Titles.SelectedItem != null && !Titles.SelectedItem.Equals("No results found :("))
            {
                ListBoxItem itm = new ListBoxItem();
                Song b = LoginScreen.allSongs.mSongs.Where(x => (" Song Title: "+x.mTitle+" Artist(s): "+x.mArtist+" Album: "+x.mAlbum+" File Type: "+x.mExtension).Equals(songStr[Titles.SelectedIndex])).Single();
                string trythis = b.mArtist + "-" + b.mTitle + b.mExtension;
                
         
                if (Adding.currentPlayList.mSongs.FirstOrDefault(x => (x.mArtist + "-" + x.mTitle + x.mExtension) == trythis) == null)
                {  
                    Adding.currentPlayList.addSong(LoginScreen.allSongs.mSongs.Where(x => (x.mArtist + "-" + x.mTitle + x.mExtension) == trythis).Single());
                    
                     ListBoxItem itm1 = new ListBoxItem();
                     itm1.Content = trythis;
                     Adding.AddingListBox.Items.Add(itm1);
                     MessageBox.Show(b.mTitle+" has been added to "+currentPlayList.mName);
                }
                else
                    MessageBox.Show("Selected song is already added in the playlist");
            }
            else
            {
                MessageBox.Show("No songs were selected");
            }


        }

        private void Reset()
        {
            Titles.ItemsSource = null;
            songObjs.Clear();
            songStr.Clear();
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
