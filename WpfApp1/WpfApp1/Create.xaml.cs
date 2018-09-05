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
        public static List<string> allItems = new List<string>();
        public static Window createWIndow;
        public static string selectedList = "";
        public Create()
        {
            InitializeComponent();
            if (allItems.Count() != 0)
                foreach (var b in allItems)
                    list.Items.Add(b);
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            this.Close();
            AfterLogin.afterLoginWindow.Show();
       
           

        }

        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            ListBoxItem itm = new ListBoxItem();
            itm.Content = newList.Text;
            allItems.Add(newList.Text);
            list.Items.Add(itm);
        }
        private void DeleteButton(object sender, RoutedEventArgs e)
        {
           
            var msg = "No Playlist was selected to delete";
            if (list.SelectedItem!= null)
                list.Items.Remove(list.SelectedItem);
            else
                MessageBox.Show(msg);
        }
        private void Go(object sender, RoutedEventArgs e)
        {
            Adding b = new Adding();
            createWIndow = this;
            this.Hide();
            b.Show();
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedList = ((ListBoxItem)list.SelectedValue).Content.ToString();
        }

        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedList = ((ListBoxItem)list.SelectedValue).Content.ToString();
            Adding b = new Adding();
            createWIndow = this;
            this.Hide();
            b.Show();
        }
    }
}
