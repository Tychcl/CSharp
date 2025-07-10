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

namespace pr24.Pages.Redact
{
    /// <summary>
    /// Логика взаимодействия для Library.xaml
    /// </summary>
    public partial class Library : Page
    {
        MainWindow.pages lastpage;
        DataBase.Tabels.Library lib;
        public Library(DataBase.Tabels.Library l, MainWindow.pages page)
        {
            InitializeComponent();
            lastpage = page;
            lib = l;
            if (lib != null)
            {
                btn.Content = "Изменить";
                name.Text = lib.Name;
                adress.Text = lib.Adress;
                city.Text = lib.City;
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(name.Text) | string.IsNullOrEmpty(adress.Text) | string.IsNullOrEmpty(city.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }
            if(lib != null)
            {
                lib.Name = name.Text;
                lib.Adress = adress.Text;
                lib.City = city.Text;
                bool x = !MainWindow.main.connect.InsUpdDel(lib,1);
                if (x)
                {
                    MessageBox.Show("Что-то не так");
                }
                else
                {
                    MessageBox.Show("Все так");
                }
                MainWindow.main.OpenPage(MainWindow.pages.Library);
            }
            else
            {
                bool x = !MainWindow.main.connect.InsUpdDel(new DataBase.Tabels.Library(MainWindow.main.connect.SetLastId(DataBase.Connect.tabels.Library),
                    name.Text, adress.Text, city.Text));
                if (x)
                {
                    MessageBox.Show("Что-то не так");
                }
                else
                {
                    MessageBox.Show("Все так");
                }
                MainWindow.main.OpenPage(MainWindow.pages.Library);
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow.main.OpenPage(lastpage);
        }
    }
}
