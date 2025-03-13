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
using Connect;

namespace pr23.Pages
{
    /// <summary>
    /// Логика взаимодействия для Order_redac.xaml
    /// </summary>
    public partial class Category_redac : Page
    {
        Connect.Tabels.category cat = null;
        public Category_redac(Connect.Tabels.category o)
        {
            InitializeComponent();
            MainWindow.connect.LoadData(Connect.DBConnection.tabels.category);
            if (o != null )
            {
                cat = o;
                TBCat.Text = o.Cat;
            }
        }

        private void Click_Call_Redact(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBCat.Text))
            {
                MessageBox.Show("category");
                return;
            }
            if(cat == null)
            {
                int id = MainWindow.connect.SetLastId(DBConnection.tabels.category);
                string query = $"INSERT INTO [category]([Код], [Cat]) VALUES ({id.ToString()}, '{TBCat.Text}')";
                var pc = MainWindow.connect.QueryAccess(query);
                if (pc != null)
                {
                    MessageBox.Show("Успешное добавленo", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.main.frame.Navigate(new Pages.Category());
                }
                else MessageBox.Show("Запрос на добавление не был обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string query = $"UPDATE [category] SET [Cat] = '{TBCat.Text}' WHERE Код = {cat.Id}";
                var pc = MainWindow.connect.QueryAccess(query);
                if (pc != null)
                {
                    MessageBox.Show("Успешное Изменено", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.main.frame.Navigate(new Pages.Category());
                }
                else MessageBox.Show("Запрос на изминение не был обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Click_Cancel_Call_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.frame.Navigate(new Pages.Category());
        }
    }
}
