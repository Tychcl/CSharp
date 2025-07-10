using pr27.Classes;
using pr27.Common;
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

namespace pr27.Pages
{
    /// <summary>
    /// Логика взаимодействия для redact.xaml
    /// </summary>
    public partial class redactafisha : Page
    {
        Afisha afisha;
        public redactafisha(Afisha a = null)
        {
            InitializeComponent();
            afisha = a;
            Theatre.All();
            foreach (Theatre i in DBConnection.Theatres)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Tag = i.Id;
                item.Content = i.Name;
                cbox.Items.Add(item);
                if (afisha != null && i.Id == afisha.Theatre)
                {
                    cbox.SelectedItem = item;
                }
            }
            if (afisha != null)
            {
                film.Text = afisha.Film;
                date.Text = DateTime.Parse(afisha.Time).Date.ToString();
                price.Text = afisha.Price.ToString();
                btn.Content = "Изменить";
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow.main.OpenPage(MainWindow.main.CP);
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(film.Text) | string.IsNullOrEmpty(date.Text) | string.IsNullOrEmpty(price.Text) | cbox.SelectedIndex == -1
                | !Check.Date(date.Text) | !Check.Digits(price.Text))
            {
                MessageBox.Show("Что-то не так");
                return;
            }
            if(afisha != null)
            {
                afisha.Film = film.Text;
                afisha.Time = date.Text;
                afisha.Price = int.Parse(price.Text);
                afisha.Theatre = (int)(cbox.SelectedItem as ComboBoxItem).Tag;
                if (DBConnection.IUD(afisha))
                {
                    MessageBox.Show("good");
                }
                else
                {
                    MessageBox.Show("bad");
                    return ;
                }
            }
            else
            {
                afisha = new Afisha(
                    id: DBConnection.GetNewId(DBConnection.tabels.Afisha),
                    theatre: (int)(cbox.SelectedItem as ComboBoxItem).Tag,
                    film: film.Text,
                    time: date.Text,
                    price: int.Parse(price.Text));
                if (DBConnection.IUD(afisha))
                {
                    MessageBox.Show("good");
                }
                else
                {
                    MessageBox.Show("bad");
                    return ;
                }
                
            }
            MainWindow.main.OpenPage(MainWindow.main.CP);
        }
    }
}
