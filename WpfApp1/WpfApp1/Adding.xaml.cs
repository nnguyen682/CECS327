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
        
        public Adding()
        {

            InitializeComponent();
            aList.ItemsSource = AfterLogin.mediaFileList;
            listTitle.Content =   Create.selectedList.ToString();
            
            foreach (var b in AfterLogin.objectUser.mPlaylists.Where(x => x.mName == Create.selectedList.ToString()).Single().mSongs)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
