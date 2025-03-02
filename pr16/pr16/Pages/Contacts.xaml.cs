using pr16.Classes;
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

namespace pr16.Pages
{
    /// <summary>
    /// Логика взаимодействия для Contacts.xaml
    /// </summary>
    public partial class Contacts : Page
    {
        public Contacts()
        {
            InitializeComponent();
        }

        private enum contacts
        {
            homeNumber,
            mobileNumber,
            email
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {

            if (!CheckRegex.CheckNumber(homeNumber.Text))
            {
                MessageBox.Show("Не правильно введен домашний номер телефона. Формат: +70000000000");
                return;
            }
            if (!CheckRegex.CheckNumber(mobileNumber.Text))
            {
                MessageBox.Show("Не правильно введен мобильный номер телефона.Формат: +70000000000");
                return;
            }
            if (!CheckRegex.CheckMail(mail.Text))
            {
                MessageBox.Show("Не правильно введена почта.Формат: имя@домен.расширение");
                return;
            }
            MainWindow.mainWindow.OpenPage(MainWindow.pages.Parents);
        }
    }
}
