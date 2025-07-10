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
    public partial class Staff : UserControl
    {
        DataBase.Tabels.Staff s;
        public Staff(DataBase.Tabels.Staff f)
        {
            InitializeComponent();
            s = f;
            if (MainWindow.main.user != 2)
            {
                red.Visibility = Visibility.Hidden;
                rem.Visibility = Visibility.Hidden;
            }
            name.Content = s.FIO;
            info.Content = s.Profession;
            TT.Content = $"Id: {s.Id}\nFIO: {f.FIO}\nLibrary: {MainWindow.main.connect.Librares.Find(x=> x.Id == s.Library).Name}\nProffession: {f.Profession}\nBirthday: {s.Birthday}\nDate: {s.Date}\nEducation: {s.Education}\nPay: {s.Pay}";
        }

        private void redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.frame.Navigate(new Pages.Redact.Staff(s, MainWindow.pages.Staff));
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            MainWindow.main.connect.InsUpdDel(s, 2);
            MainWindow.main.OpenPage(MainWindow.pages.Staff);
        }
    }
}
