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
    /// Логика взаимодействия для redacttheatre.xaml
    /// </summary>
    public partial class redacttheatre : Page
    {
        Theatre theatre;
        public redacttheatre(Theatre t = null)
        {
            InitializeComponent();
            theatre = t;
            if(theatre != null)
            {
                name.Text = theatre.Name;
                RC.Text = theatre.RoomCount.ToString();
                PC.Text = theatre.PlaceCount.ToString();
                btn.Content = "Изменить";
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            MainWindow.main.OpenPage(MainWindow.main.CP);
        }

        private void add(object sender, RoutedEventArgs e)
        { 
            if(string.IsNullOrEmpty(name.Text) | string.IsNullOrEmpty(RC.Text) | string.IsNullOrEmpty(PC.Text) |
                !Check.Digits(RC.Text) | !Check.Digits(PC.Text))
            {
                MessageBox.Show("Что-то не так");
                return;
            }
            if(theatre != null)
            {
                theatre.Name = name.Text;
                theatre.RoomCount = int.Parse(RC.Text);
                theatre.PlaceCount = int.Parse(PC.Text);
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
                    id: DBConnection.GetNewId(DBConnection.tabels.Theatre),
                    name: name.Text,
                    RC: int.Parse(RC.Text),
                    PC: int.Parse(PC.Text));
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
