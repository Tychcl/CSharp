using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr29.Pages.Clubs.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        Main M;
        Models.Clubs Club;
        public Item(Models.Clubs c,Main m)
        {
            InitializeComponent();
            this.Name.Text = c.Name;
            this.Address.Text = c.Address;
            this.WorkTime.Text = c.WorkTime;
            this.M = m;
            this.Club = c;
        }

        private void EditClub(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Clubs.Add(this.M, this.Club));
        }

        private void DeleteClub(object sender, RoutedEventArgs e)
        {
            M.all.Clubs.Remove(Club);
            M.all.SaveChanges();
            M.Parent.Children.Remove(this);
        }
    }
}
