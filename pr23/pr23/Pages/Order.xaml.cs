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
using Connect;

namespace pr23.Pages
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        List<Connect.Tabels.order> list;

        public Order()
        {
            InitializeComponent();
            MainWindow.connect.LoadData(Connect.DBConnection.tabels.orders);
            list = MainWindow.connect.orders;
            UpdUi();
        }

        private void UpdUi()
        {
            parrent.Children.Clear();
            foreach(Connect.Tabels.order o in list)
            {
                parrent.Children.Add(new Items.OrderItm(o));
            }
            parrent.Children.Add(new Items.Add_itm("order"));
        }

    }
}
