using pr29.Classes;
using pr29.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr29.Pages
{
    /// <summary>
    /// Логика взаимодействия для Club.xaml
    /// </summary>
    public partial class Club : Page
    {
        List<Models.Club> clubs;
        public Club()
        {
            if (MainWindow.CurrentUser != null)
            {
                InitializeComponent();
                if (MainWindow.CurrentUser.RoleId == 2)
                {
                    add.Visibility = Visibility.Visible;
                }
                using (var context = new ClubContext())
                {
                    clubs = context.Clubs.ToList();
                    foreach (var club in clubs)
                        ClubParent.Children.Add(new Elements.Club(club));
                }
                UserName.Content = MainWindow.CurrentUser.Name;
            }
        }

        private void AddClub(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.OpenPage(new Pages.SaveClub());
        }

        private void Comp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.OpenPage(new Pages.Computers());
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.OpenPage(new Pages.Main());
        }
    }
}
