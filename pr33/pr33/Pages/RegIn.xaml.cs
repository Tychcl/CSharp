using System;
using System.IO;
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
using Microsoft.Win32;
using pr33.Classes;

namespace pr33.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegIn.xaml
    /// </summary>
    public partial class RegIn : Page
    {
        private string UserImgSrc;
        public RegIn()
        {
            InitializeComponent();
        }

        private void SetImage(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите фотографию";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                imgSource.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                UserImgSrc = openFileDialog.FileName;
            }
        }
        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.SignIn());
        }

        private void reg(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(name.Text) 
                | (!Regex.IsMatch(phonemail.Text, @"\+7[0-9]{10}$") & !Regex.IsMatch(phonemail.Text, @"8[0-9]{10}$") & !Regex.IsMatch(phonemail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))|
                string.IsNullOrEmpty(password.Text) | string.IsNullOrEmpty(UserImgSrc))
            {
                MessageBox.Show("Не верно заполнено");
                return;
            }
            using(var con = new Context())
            {
                var list = con.User.ToList();
                if (list.Find(x => x.PhoneMail == phonemail.Text) == null)
                {
                    Classes.User u = new Classes.User(name.Text, phonemail.Text, password.Text, File.ReadAllBytes(UserImgSrc));
                    con.User.Add(u);
                    con.SaveChanges();
                    MainWindow.init.frame.Navigate(new Pages.SignIn());
                    return;
                }
                else
                {
                    MessageBox.Show("Аккаунт уже существует");
                }
            }
        }
    }
}
