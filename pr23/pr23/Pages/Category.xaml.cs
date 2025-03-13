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

namespace pr23.Pages
{
    /// <summary>
    /// Логика взаимодействия для Category.xaml
    /// </summary>
    public partial class Category : Page
    {
        List<Connect.Tabels.category> list;
        public Category()
        {
            InitializeComponent();
            MainWindow.connect.LoadData(Connect.DBConnection.tabels.category);
            list = MainWindow.connect.cats;
            UpdUi();
        }

        private void UpdUi()
        {
            parrent.Children.Clear();
            foreach (Connect.Tabels.category o in list)
            {
                parrent.Children.Add(new Items.CatItm(o));
            }
            parrent.Children.Add(new Items.Add_itm("category"));
        }

        private void go(object sender, RoutedEventArgs e)
        {

        }
    }
}
