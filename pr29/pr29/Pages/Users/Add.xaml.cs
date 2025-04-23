using pr29.Classes;
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

namespace pr29.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public ClubsContext all = new ClubsContext();
        Main M;
        Models.Users User;
        public Add(Main m, Models.Users u = null)
        {
            InitializeComponent();
            this.M = m;
            foreach (Models.Clubs i in all.Clubs)
            {
                ComboBoxItem c = new ComboBoxItem();
                c.Tag = i.Id;
                c.Content = i.Name;
                ClubCB.Items.Add(c);
            }
            if (u != null)
            {
                User = u;
                RentStart.Text = u.RentStart.ToString("yyyy-MM-dd");
                dur.Text = u.Duration.ToString();
                RentTime.Text = u.RentStart.ToString("HH:mm");
                FIO.Text = u.FIO;
                ClubCB.SelectedItem = all.Clubs.Where(x=>x.Id == User.Id).First().Name;
                btn.Content = "Изменить";
            }
        }

        private void EditClub(object sender, RoutedEventArgs e)
        {
            DateTime dt = new DateTime();
            DateTime.TryParse(RentStart.Text, out dt);
            dt = dt.Add(TimeSpan.Parse(this.RentStart.Text));

            if(this.User == null)
            {
                User = new Models.Users();
                User.FIO = FIO.Text;
                User.RentStart = dt;
                User.Duration = Convert.ToInt32(dur.Text);
                User.Club = (int)(ClubCB.SelectedItem as ComboBoxItem).Tag;
                M.all.Users.Add(this.User);
            }
            else
            {
                User.FIO = FIO.Text;
                User.RentStart = dt;
                User.Duration = Convert.ToInt32(dur.Text);
                User.Club = (int)(ClubCB.SelectedItem as ComboBoxItem).Tag;
            }
            M.all.SaveChanges();
            MainWindow.init.frame.Navigate(new Pages.Users.Main());
        }

    }
}
