using pr27.Classes;
using pr27.Common;
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

namespace pr27
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main;
        public pages CP;
        public MainWindow()
        {
            InitializeComponent();
            main = this;
            OpenPage(pages.Theatre);
        }

        public void OpenPage(pages p)
        {
            CP = p;
            if (p == pages.Afisha)
            {
                frame.Navigate(new Pages.View(pages.Afisha));
            }
            if (p == pages.Theatre)
            {
                frame.Navigate(new Pages.View(pages.Theatre));
            }
        }

        public enum pages
        {
            Afisha, Theatre
        }

        private void got(object sender, RoutedEventArgs e)
        {
            OpenPage(pages.Theatre);
            (sender as Button).Foreground = new SolidColorBrush(Colors.Red);
            afi.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void goa(object sender, RoutedEventArgs e)
        {
            OpenPage(pages.Afisha);
            (sender as Button).Foreground = new SolidColorBrush(Colors.Red);
            thet.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
