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

namespace pr24.Pages.View
{
    /// <summary>
    /// Логика взаимодействия для Fond.xaml
    /// </summary>
    public partial class Refill : Page
    {
        public Refill()
        {
            InitializeComponent();
            UpdList();
        }
        public void UpdList()
        {
            parrent.Children.Clear();
            //MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Type);
            //MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Fond);
            //MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Staff);
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Refill);
            foreach (DataBase.Tabels.Refill f in MainWindow.main.connect.Refills)
            {
                parrent.Children.Add(new Items.Refill(f));
            }
            if (MainWindow.main.user != 0)
                parrent.Children.Add(new Items.Add(MainWindow.pages.Refill));
        }
    }
}
