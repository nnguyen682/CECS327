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
        public Create()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Profile b = new Profile();
            this.Close();
            b.Show();

        }

        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            ListBoxItem itm = new ListBoxItem();
            itm.Content = newList.Text;
            list.Items.Add(itm);
        }
        private void DeleteButton(object sender, RoutedEventArgs e)
        {
           
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
