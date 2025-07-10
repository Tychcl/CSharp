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
    /// Логика взаимодействия для Staff.xaml
    /// </summary>
    public partial class Refill : UserControl
    {
        DataBase.Tabels.Refill r;
        public Refill(DataBase.Tabels.Refill f)
        {
            InitializeComponent();
            r = f;
            if (MainWindow.main.user == 0)
            {
                red.Visibility = Visibility.Hidden;
                rem.Visibility = Visibility.Hidden;
            }
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Fond);
            name.Content = MainWindow.main.connect.Fonds.Find(x => x.Id == r.Fond).Name;
            info.Content = r.Count + " " + MainWindow.main.connect.Types.Find(x => x.Id == r.Type).Name;
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Staff);
            TT.Content = $"Id: {r.Id}\nFond: {MainWindow.main.connect.Fonds.Find(x => x.Id == r.Fond).Name}\nStaff: {MainWindow.main.connect.Staffs.Find(x => x.Id == r.Staff).FIO}\nType: {MainWindow.main.connect.Types.Find(x => x.Id == r.Type).Name}\nDate Refill: {r.DateRefill}\nSource: {r.Source}\nPublisher: {r.Publisher}\nDate Publication: {r.DatePublication}\nCount: {r.Count}";
        }

        private void redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.frame.Navigate(new Pages.Redact.Refill(r, MainWindow.pages.Refill));
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            MainWindow.main.connect.InsUpdDel(r, 2);
            MainWindow.main.OpenPage(MainWindow.pages.Refill);
        }
    }
}
