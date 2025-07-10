using DataBase.Tabels;
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

namespace pr24.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login(object sender, RoutedEventArgs e)
        {
            MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Staff);
            Staff s = MainWindow.main.connect.Staffs.Find(x => x.Email == email.Text && x.Password == password.Text);
            if (combo.SelectedIndex == 1 && s == null)
            {
                MessageBox.Show("Неверная почта или пароль");
                return;
            }
            else if(combo.SelectedIndex == 1 && s != null)
            {
                MainWindow.main.StaffId = s.Id;
            }
            if(combo.SelectedIndex == 2 && password.Text != "Password123")
            {
                MessageBox.Show("Не верный пароль");
                return;
            }
            if(combo.SelectedIndex != -1)
            {
                MainWindow.main.user = combo.SelectedIndex;
                MainWindow.main.connect.LoadData(DataBase.Connect.tabels.Type);
                MainWindow.main.OpenPage(MainWindow.pages.Library);
                Thickness m = MainWindow.main.frame.Margin;
                m.Top = 40;
                MainWindow.main.frame.Margin = m;
                MainWindow.main.TopMenu.Visibility = Visibility.Visible;
            }
        }

        private void check(object sender, SelectionChangedEventArgs e)
        {
            logbtn.Height = 22;
            logbtn.Visibility = Visibility.Visible;
            if(combo.SelectedIndex == 1)
            {
                l.Height = 48;
                l.Visibility = Visibility.Visible;
                p.Height = 48;
                p.Visibility = Visibility.Visible;
            }
            if(combo.SelectedIndex == 2)
            {
                p.Height = 48;
                p.Visibility = Visibility.Visible;
                l.Height = 0;
                l.Visibility = Visibility.Hidden;
            }
        }
    }
}
