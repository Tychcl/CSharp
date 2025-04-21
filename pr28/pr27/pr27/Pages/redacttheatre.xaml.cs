using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities;
using pr27.Classes;
using pr27.Common;
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

namespace pr27.Pages
{
    /// <summary>
    /// Логика взаимодействия для redacttheatre.xaml
    /// </summary>
    public partial class redacttheatre : Page
    {
        Theatre theatre;
        public redacttheatre(Theatre t = null)
        {
            InitializeComponent();
            if (t != null)
            {
                theatre = t;
                name.Text = theatre.Name;
                adr.Text = theatre.Adres;
                btn.Content = "Изменить";
                time.Text = theatre.Work;
            }
            
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow.main.OpenPage(MainWindow.main.CP);
        }

        private void add(object sender, RoutedEventArgs e)
        { 
            if(string.IsNullOrEmpty(name.Text) | string.IsNullOrEmpty(adr.Text) | string.IsNullOrEmpty(time.Text))
            {
                MessageBox.Show("Что-то не заполнено");
                return;
            }
            if(theatre != null)
            {
                theatre.Name = name.Text;
                theatre.Adres = adr.Text;
                theatre.Work = time.Text;
                if (DBConnection.IUD(theatre))
                {
                    MessageBox.Show("good");
                }
                else
                {
                    MessageBox.Show("bad");
                    return;
                }
            }
            else
            {
                theatre = new Theatre(
                    id: DBConnection.GetNewId(DBConnection.tabels.Club),
                    name: name.Text,
                    adr: adr.Text,
                    work: time.Text);
                if (DBConnection.IUD(theatre))
                {
                    MessageBox.Show("good");
                }
                else
                {
                    MessageBox.Show("bad");
                    return;
                }
            }
            MainWindow.main.OpenPage(MainWindow.main.CP);
        }
        }
}
