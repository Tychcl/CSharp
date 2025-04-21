using System;
using System.Collections.Generic;
using System.Linq;
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
using pr29.Classes;

namespace pr29.Pages.Users.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public ClubsContext all = new ClubsContext();
        Main M;
        Models.Users User;
        public Item(Models.Users u,Main m)
        {
            InitializeComponent();
            this.FIO.Text = u.FIO;
            this.RentStart.Text = u.RentStart.ToString("yyyy-MM-dd");
            this.RentTime.Text = u.RentStart.ToString("HH:mm");
            this.Duration.Text = u.Duration.ToString();
            this.Club.Text = all.Clubs.Where(x=>x.Id == u.Club).First().Name;
            this.M = m;
            this.User = u;
        }

        private void EditClub(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Users.Add(this.M, this.User));
        }

        private void DeleteClub(object sender, RoutedEventArgs e)
        {
            M.all.Users.Remove(User);
            M.all.SaveChanges();
            M.Parent.Children.Remove(this);
        }
    }
}
