using pr27.Classes;
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

namespace pr27.Items
{
    /// <summary>
    /// Логика взаимодействия для add.xaml
    /// </summary>
    public partial class add : UserControl
    {
        public add()
        {
            InitializeComponent();
        }

        private void click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.main.CP == MainWindow.pages.Afisha)
            {
                MainWindow.main.frame.Navigate(new Pages.redactafisha());
            }
            if (MainWindow.main.CP == MainWindow.pages.Theatre)
            {
                MainWindow.main.frame.Navigate(new Pages.redacttheatre());
            }
        }
    }
}
