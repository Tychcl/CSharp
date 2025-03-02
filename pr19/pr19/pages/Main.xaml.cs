using pr19.Classes;
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
 
namespace pr19.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page

    {
        public static Main main;
        public List<Classes.Item> items = new List<Classes.Item>();
        public Main()
        {
            InitializeComponent();
            main = this;
            //добавляем элемент в коллекцию
            items.Add(new Item("Шакаф", 20000, "shkaf.jpg", "Для гостинной"));
            items.Add(new Item("Диван", 65000, "divanGost.jpg", "Для гостинной"));
            items.Add(new Item("Стол", 17000, "stolKab.jpg", "Для Кабинета")); 
            items.Add(new Item("Шкаф", 70000, "hkafKab.jpg", "Для Кабинета"));
            items.Add(new Item("Кресло", 34000, "kresloKab.jpg", "Для Кабинета"));
            items.Add(new Item("Ковер", 15000, "koverGost.jpg", "Для гостинной"));
            items.Add(new Item("Телевизор", 105000, "tvGost.jpg", "Для гостинной"));
            //вызываем метод генерации интерфейса
            LoadItems();
            bascet.Content = $"Корзина ({MainWindow.Cost})";
        }
        public void LoadItems() {
            parent.Children.Clear(); // очищаем элемент parent
            foreach (Item item in items) {
                //добавляем элемент

            parent.Children.Add(new Elements.Item(item));
            }
        }

        private void OpenCategories(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.OpenPage(new Pages.Category());
        }
        public void AddCost(float price)
        {
            MainWindow.Cost += price;
            bascet.Content = $"Корзина ({MainWindow.Cost})";
        }

    }
}
