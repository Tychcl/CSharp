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
using Connect;

namespace pr23
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DBConnection connect;
        public enum pages
        {
            Ord, Cat
        }
        public static MainWindow main;

        public MainWindow()
        {
            InitializeComponent();
            main = this;
            connect = new DBConnection();
            OpenPages(pages.Ord);
        }

        public void OpenPages(pages _pages)
        {
            if (_pages == pages.Ord)
            {
                frame.Navigate(new Pages.Order());
            }
            if (_pages == pages.Cat)
            {
                frame.Navigate(new Pages.Category());
            }
        }

        private void GetOrder(object sender, RoutedEventArgs e)
        {
            OpenPages(pages.Ord);
        }

        private void GetCategory(object sender, RoutedEventArgs e)
        {
            OpenPages(pages.Cat);
        }
    }
}
