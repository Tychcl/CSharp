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
        private List<Page> PL = new List<Page>() { new Pages.Stopwatch(), new Pages.MinWatch() };
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
            frame.Navigate(PL[(int)_page]);
        }

        private void GoTimer(object sender, RoutedEventArgs e)
        {

        }

        private void GoSec(object sender, RoutedEventArgs e)
        {
            if (!(frame.Content as Page is Pages.Stopwatch))
            {
                //frame.Navigate(SW);
            }
        }
    }
}
