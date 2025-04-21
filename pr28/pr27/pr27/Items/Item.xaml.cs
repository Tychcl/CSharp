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
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace pr27.Items
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        object item;
        public Item(object i)
        {
            InitializeComponent();
            item = i;
            if(item is Afisha a)
            {
                name.Content = a.FIO;
                des.Content = DBConnection.Theatres.Find(x=>x.Id == a.Club).Name;
            }
            if(item is Theatre t)
            {
                name.Content = t.Name;
                des.Content = t.Work;
            }
        }

        private void del(object sender, RoutedEventArgs e)
        {
            if (MainWindow.main.CP == MainWindow.pages.Afisha)
            {
                DBConnection.IUD(item as Afisha,true);
            }
            if (MainWindow.main.CP == MainWindow.pages.Theatre)
            {
                DBConnection.IUD(item as Theatre, true);
            }
            MainWindow.main.OpenPage(MainWindow.main.CP);
        }

        private void red(object sender, RoutedEventArgs e)
        {
            if(MainWindow.main.CP == MainWindow.pages.Afisha)
            {
                MainWindow.main.frame.Navigate(new Pages.redactafisha(item as Afisha));
            }
            if (MainWindow.main.CP == MainWindow.pages.Theatre)
            {
                MainWindow.main.frame.Navigate(new Pages.redacttheatre(item as Theatre));
            }
        }
    }
}
