using System;
using System.Collections.Generic;
using System.Data.Common;
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
using DataBase;

namespace pr24
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Connect connect;
        public static MainWindow main;
        public int user;
        public int StaffId;
        public enum pages
        {
            Login, Library, Fond, Refill, Staff
        }

        public MainWindow()
        {
            InitializeComponent();
            connect = new Connect();
            main = this;
            OpenPage(pages.Login);
            connect.LoadData(DataBase.Connect.tabels.Type);
        }

        public void OpenPage(pages _p)
        {
            if (pages.Login == _p)
            {
                frame.Navigate(new Pages.Login());
            }
            if(pages.Library == _p)
            {
                frame.Navigate(new Pages.View.Library());
            }
            if (pages.Fond == _p)
            {
                frame.Navigate(new Pages.View.Fond());
            }
            if (pages.Refill == _p)
            {
                frame.Navigate(new Pages.View.Refill());
            }
            if (pages.Staff == _p)
            {
                frame.Navigate(new Pages.View.Staff());
            }
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            user = -1;
            Thickness m = frame.Margin;
            m.Top = 0;
            frame.Margin = m;
            TopMenu.Visibility = Visibility.Hidden;
            OpenPage(pages.Login);
        }

        private void libs(object sender, RoutedEventArgs e)
        {
            OpenPage(pages.Library);
        }

        private void staffs(object sender, RoutedEventArgs e)
        {
            OpenPage(pages.Staff);
        }

        private void refills(object sender, RoutedEventArgs e)
        {
            OpenPage(pages.Refill);
        }

        private void fonds(object sender, RoutedEventArgs e)
        {
            OpenPage(pages.Fond);
        }
    }
}
