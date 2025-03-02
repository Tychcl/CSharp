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

namespace _15pr
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenPages(pages.stopwatch);
        }

        public enum pages
        {
            stopwatch,
            MinWatch
        }

        public void OpenPages(pages _page)
        {
            if (_page == pages.stopwatch)
            {
                frame.Navigate(new Pages.Stopwatch());
            }
            if (_page == pages.MinWatch)
            {
                frame.Navigate(new Pages.MinWatch());
            }
        }

        private void GoTimer(object sender, RoutedEventArgs e)
        {
            OpenPages(pages.MinWatch);
        }

        private void GoSec(object sender, RoutedEventArgs e)
        {
            OpenPages(pages.stopwatch);
        }
    }
}
