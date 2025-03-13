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

namespace pr23.Items
{
    /// <summary>
    /// Логика взаимодействия для Add_itm.xaml
    /// </summary>
    public partial class Add_itm : UserControl
    {
        string page;
        public Add_itm(string p)
        {
            InitializeComponent();
            page = p;
        }

        private void Click_add(object sender, RoutedEventArgs e)
        {
            if(page == "order")
            {
                MainWindow.main.frame.Navigate(new Pages.Order_redac(null));
            }
            if (page == "category")
            {
                MainWindow.main.frame.Navigate(new Pages.Category_redac(null));
            }
        }
    }
}
