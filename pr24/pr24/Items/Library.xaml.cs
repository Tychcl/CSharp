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
    /// Логика взаимодействия для Type.xaml
    /// </summary>
    public partial class Library : UserControl
    {
        DataBase.Tabels.Library lib;
        public Library(DataBase.Tabels.Library f)
        {
            InitializeComponent();
            lib = f;
            if (MainWindow.main.user != 2)
            {
                red.Visibility = Visibility.Hidden;
                rem.Visibility = Visibility.Hidden;
            }
            name.Content = lib.Name;
            info.Content = lib.Adress + " " + lib.City;
            TT.Content = $"Id: {f.Id}\nName: {f.Name}\nAdress: {f.Adress}\nCity: {f.City}";
        }

        private void redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.frame.Navigate(new Pages.Redact.Library(lib,MainWindow.pages.Library));
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            MainWindow.main.connect.InsUpdDel(lib, 2);
            MainWindow.main.OpenPage(MainWindow.pages.Library);
        }
    }
}
