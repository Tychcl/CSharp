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
    /// Логика взаимодействия для Type.xaml
    /// </summary>
    public partial class Library : Page
    {
        public Library()
        {
            InitializeComponent();
            UpdList();
        }
        public void UpdList()
        {
            parrent.Children.Clear();
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Library);
            foreach (DataBase.Tabels.Library f in MainWindow.main.connect.Librares)
            {
                parrent.Children.Add(new Items.Library(f));
            }
            if(MainWindow.main.user == 2)
                parrent.Children.Add(new Items.Add(MainWindow.pages.Library));
        }
    }
}
