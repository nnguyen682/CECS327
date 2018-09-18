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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public static Window createWIndow;
        public static string selectedList = "";
        
        public Create()
        {
            InitializeComponent();
            if (AfterLogin.objectUser.mPlaylists != null)
            {
                foreach (var b in AfterLogin.objectUser.mPlaylists) // add all the playlist name to the list box
                {
                    ListBoxItem itm = new ListBoxItem();
                    itm.Content = b.mName;
                    list.Items.Add(itm);
                }
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e) // Going back to the After Login Screen
        {
            selectedList = ""; 
            list.Items.Clear();
            this.Hide();
            AfterLogin.afterLoginWindow.Show();
       
           

        }
        private void Playlist_KeyDown(object sender, KeyEventArgs e) // implementing enter key so it will add the playlist name to the list box
        {
            if (e.Key == Key.Enter)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = newList.Text;

                if (AfterLogin.objectUser.mPlaylists.FirstOrDefault(x => x.mName == newList.Text) == null) // check if the playlist name already exist or not
                {
                    AfterLogin.objectUser.mPlaylists.Add(new Playlist(newList.Text));
                    list.Items.Add(itm);
                }
                else
                    MessageBox.Show("Please choose a different name for the playlist");
                AfterLogin.afterLoginWindow.reloadPlaylists();

            }
        }
        
        private void AddButton(object sender, RoutedEventArgs e) // add the playlist name to the list box by clicking the add button
        {
            ListBoxItem itm = new ListBoxItem();
            if(!String.IsNullOrWhiteSpace(newList.Text))
            {
                itm.Content = newList.Text;

                if (AfterLogin.objectUser.mPlaylists.FirstOrDefault(x => x.mName == newList.Text) == null)
                {
                    AfterLogin.objectUser.mPlaylists.Add(new Playlist(newList.Text));
                    list.Items.Add(itm);
                }
                else
                    MessageBox.Show("Please choose a different name for the playlist");
                AfterLogin.afterLoginWindow.reloadPlaylists();
            }
        }
        private void DeleteButton(object sender, RoutedEventArgs e) // remnove the name of the playlist from the list box
        {
           
            var msg = "No Playlist was selected to delete";
            if (list.SelectedItem != null)
            {
                string b = ((ListBoxItem)list.SelectedItem).Content.ToString();
                if (AfterLogin.afterLoginWindow.currPlaylistName == b)
                {
                    AfterLogin.ax.close();
                }
                list.Items.Remove(list.SelectedItem);
                AfterLogin.objectUser.mPlaylists.Remove(AfterLogin.objectUser.mPlaylists.Where(x => x.mName == b).Single());
                AfterLogin.afterLoginWindow.reloadPlaylists();
            }
            else
                MessageBox.Show(msg);
        }
        private void Go(object sender, RoutedEventArgs e) // Go to the Adding Screen by the button edit
        {
            if (list.SelectedItem != null)
            {
                Adding b = new Adding();
                createWIndow = this;
                this.Hide();
                b.Show();
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // save the name of the selected playlist for later use
        {
            if (list.SelectedItem != null)
                selectedList = ((ListBoxItem)list.SelectedValue).Content.ToString();
        }

        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e) // Go the the Adding Screen by double click on the name of the playlist
        {
            if (list.SelectedValue != null)
            {
                selectedList = ((ListBoxItem)list.SelectedValue).Content.ToString();
                Adding b = new Adding();
                createWIndow = this;
                this.Hide();
                b.Show();
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // overide x button
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
    }
}
