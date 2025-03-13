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
    public partial class Order_redac : Page
    {
        Connect.Tabels.order order = null;
        public Order_redac(Connect.Tabels.order o)
        {
            InitializeComponent();
            MainWindow.connect.LoadData(Connect.DBConnection.tabels.category);
            foreach(Connect.Tabels.category c in MainWindow.connect.cats)
            {
                ComboBoxItem cat = new ComboBoxItem();
                cat.Tag = c.Id;
                cat.Content = c.Cat;
                combo.Items.Add(cat);
            }
            if (o != null )
            {
                order = o;
                fio.Text = o.FIO;
                msg.Text = o.Message;
                adress.Text = o.Adress;
                email.Text = o.Email;
                combo.SelectedIndex = o.Category;
            }
        }

        private void Click_Call_Redact(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.connect.ItsOnlyFIO(fio.Text))
            {
                MessageBox.Show("FIO");
                return;
            }
            if (!MainWindow.connect.ItsEmail(email.Text))
            {
                MessageBox.Show("EMail");
                return;
            }
            if(combo.SelectedIndex == -1)
            {
                MessageBox.Show("Category");
                return;
            }
            if(order == null)
            {
                int id = MainWindow.connect.SetLastId(DBConnection.tabels.orders);
                string query = $"INSERT INTO [orders]([Код], [FIO], [Message], [Adress], [Date_time], [Email], [Category]) VALUES ({id.ToString()}, '{fio.Text}', '{msg.Text}', '{adress.Text}', '{DateTime.Now.ToString()}', '{email.Text}', {combo.SelectedIndex.ToString()})";
                var pc = MainWindow.connect.QueryAccess(query);
                if (pc != null)
                {
                    MessageBox.Show("Успешное добавленo", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.main.frame.Navigate(new Pages.Order());
                }
                else MessageBox.Show("Запрос на добавление не был обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string query = $"UPDATE [orders] SET [FIO] = '{fio.Text}', [Message]='{msg.Text}', [Adress]='{adress.Text}', [Email]='{email.Text}', [Category]={combo.SelectedIndex.ToString()} WHERE Код = {order.Id}";
                var pc = MainWindow.connect.QueryAccess(query);
                if (pc != null)
                {
                    MessageBox.Show("Успешное Изменено", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.main.frame.Navigate(new Pages.Order());
                }
                else MessageBox.Show("Запрос на изминение не был обработан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Click_Cancel_Call_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.frame.Navigate(new Pages.Order());
        }
    }
}
