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
    /// Логика взаимодействия для Fond.xaml
    /// </summary>
    public partial class Fond : UserControl
    {
        DataBase.Tabels.Fond f;
        public Fond(DataBase.Tabels.Fond ff)
        {
            InitializeComponent();
            this.f = ff;
            if (MainWindow.main.user != 2)
            {
                red.Visibility = Visibility.Hidden;
                rem.Visibility = Visibility.Hidden;
            }
            name.Content = f.Name;
            info.Content = MainWindow.main.connect.Librares.Find(x => x.Id == f.Library).Name;
            TT.Content = $"Id: {f.Id}\nName: {f.Name}\nLibrary: {MainWindow.main.connect.Librares.Find(x => x.Id == f.Library).Name}\nBooks: {f.Books}\nPaper: {f.Paper}\nMagazine: {f.Magazine}\nCollection: {f.Collection}\nDessertation: {f.Dissertation}\nReport: {f.Report}";
        }

        private void redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.frame.Navigate(new Pages.Redact.Fond(f, MainWindow.pages.Fond));
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            MainWindow.main.connect.InsUpdDel(f, 2);
            MainWindow.main.OpenPage(MainWindow.pages.Fond);
        }
    }
}
