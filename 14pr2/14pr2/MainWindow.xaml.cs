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
using System.Xml.Serialization;

namespace _14pr2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Classes.Passport> Passports = new List<Classes.Passport>();
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            delbtn.Visibility = Visibility.Hidden;
            updbtn.Visibility = Visibility.Hidden;
        }

        public void LoadPassport()
        {
            lv_passport.Items.Clear();
            foreach(Classes.Passport passport in Passports)
            {
                lv_passport.Items.Add(passport);
            }
        }

        private void Add(object sender, RoutedEventArgs e) => new Windows.Add(null).ShowDialog();
    
        private void Update(object sender, RoutedEventArgs e)
        {
            if(lv_passport.SelectedIndex > -1)
            {
                new Windows.Add(lv_passport.SelectedItem as Classes.Passport).ShowDialog();
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (lv_passport.SelectedIndex > -1)
            {
                Passports.Remove(lv_passport.SelectedItem as Classes.Passport);
                LoadPassport();
            }
        }

        private void SelectChange(object sender, SelectionChangedEventArgs e)
        {
            if (lv_passport.SelectedIndex > -1)
            {
                delbtn.Visibility = Visibility.Visible;
                updbtn.Visibility = Visibility.Visible;
            }
            else
            {
                delbtn.Visibility = Visibility.Hidden;
                updbtn.Visibility = Visibility.Hidden;
            }
        }

        private void search(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(TBSearch.Text))
            {
                LoadPassport();
                return;
            }
            lv_passport.Items.Clear();
            foreach (Classes.Passport passport in Passports)
            {
                if ($"{passport.FirstName} {passport.Name} {passport.LastName}".ToLower().Contains(TBSearch.Text.ToLower()))
                {
                    lv_passport.Items.Add(passport);
                }
            }
        }
    }
}
