using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using pr33.Classes;
using System.Xml.Linq;

namespace pr33.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.RegIn());
        }

        private void sign(object sender, RoutedEventArgs e)
        {
            if((!Regex.IsMatch(phonemail.Text, @"\+7[0-9]{10}$") & !Regex.IsMatch(phonemail.Text, @"8[0-9]{10}$") & !Regex.IsMatch(phonemail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) | string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("Не верно заполнено");
                return;
            }
            using (var con = new Context())
            {
                if (con.User.ToList().Find(x => x.PhoneMail == phonemail.Text && x.Password == password.Text) is Classes.User sign)
                {
                    MainWindow.init.user = sign;
                    MainWindow.init.frame.Navigate(new Pages.Messanger());
                }
                else
                {
                    MessageBox.Show("Что то не верно заполнено");
                }
            }
        }
    }
}
