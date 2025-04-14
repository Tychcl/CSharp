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

namespace pr26.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }


        private void exit(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Close();
        }

        private void search(object sender, RoutedEventArgs e)
        {
            MainWindow.main.frame.Navigate(new Pages.Ticket(from.Text, to.Text));
        }
    }
}
