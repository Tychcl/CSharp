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

namespace pr29.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        Main M;
        Models.Clubs Club;
        public Add(Main m, Models.Clubs club = null)
        {
            InitializeComponent();
            this.M = m;
            if (club != null)
            {
                this.Club = club;
                Name.Text = club.Name;
                Address.Text = club.Address;
                WorkTime.Text = club.WorkTime;
                btn.Content = "Изменить";
            }
        }

        private void EditClub(object sender, RoutedEventArgs e)
        {
            if(this.Club == null)
            {
                Club = new Models.Clubs();
                Club.Name = Name.Text;
                Club.Address = Address.Text;
                Club.WorkTime = WorkTime.Text;
                M.all.Clubs.Add(Club);
            }
            else
            {
                Club.Name = Name.Text;
                Club.Address = Address.Text;
                Club.WorkTime= WorkTime.Text;
            }
            M.all.SaveChanges();
            MainWindow.init.frame.Navigate(new Pages.Clubs.Main());
        }
    }
}
