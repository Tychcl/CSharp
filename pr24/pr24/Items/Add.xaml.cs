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

namespace pr24.Items
{
    /// <summary>
    /// Логика взаимодействия для Redact.xaml
    /// </summary>
    public partial class Add : UserControl
    {
        MainWindow.pages page;
        public Add(MainWindow.pages page)
        {
            InitializeComponent();
            this.page = page;
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if(MainWindow.pages.Library == page)
            {
                MainWindow.main.frame.Navigate(new Pages.Redact.Library(null,page));
            }
            if (MainWindow.pages.Staff == page)
            {
                MainWindow.main.frame.Navigate(new Pages.Redact.Staff(null, page));
            }
            if (MainWindow.pages.Fond == page)
            {
                MainWindow.main.frame.Navigate(new Pages.Redact.Fond(null, page));
            }
            if (MainWindow.pages.Refill == page)
            {
                MainWindow.main.frame.Navigate(new Pages.Redact.Refill(null, page));
            }
        }
    }
}
