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

namespace pr23.Items
{
    /// <summary>
    /// Логика взаимодействия для OrderItm.xaml
    /// </summary>
    public partial class CatItm : UserControl
    {
        Connect.Tabels.category cat;
        public CatItm(Connect.Tabels.category c)
        {
            InitializeComponent();
            cat = c;
            CatName.Content = cat.Cat;
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connect.LoadData(Connect.DBConnection.tabels.orders);
                var pc = MainWindow.connect.QueryAccess($"DELETE FROM [category] WHERE [Код] = {cat.Id.ToString()}");
                if (pc != null)
                {
                    MessageBox.Show("Успешное удаление клиента", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.connect.LoadData(Connect.DBConnection.tabels.orders);
                    MainWindow.main.frame.Navigate(new Pages.Category());
                }
                else MessageBox.Show("Запрос на удаление клиента не был обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.frame.Navigate(new Pages.Category_redac(cat));
        }
    }
}
