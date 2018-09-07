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
                foreach (var b in AfterLogin.objectUser.mPlaylists)
                {
                    ListBoxItem itm = new ListBoxItem();
                    itm.Content = b.mName;
                    list.Items.Add(itm);
                }
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            selectedList = "";
            list.Items.Clear();
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
            
            list.Items.Add(itm);
            AfterLogin.objectUser.mPlaylists.Add(new Playlist(newList.Text));
            newList.Text = "";
        }
        private void DeleteButton(object sender, RoutedEventArgs e)
        {
           
            var msg = "No Playlist was selected to delete";
            if (list.SelectedItem != null)
            {
                list.Items.Remove(list.SelectedItem);
   
            }
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
            if (list.SelectedItem != null)
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
