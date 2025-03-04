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
        public int id;
        public Main(int i)
        {
            InitializeComponent();
            id = i;
            main = this;
            //добавляем элемент в коллекцию
            items.Add(new Item("Жилки", 50, "zil.jpg", 1));
            items.Add(new Item("Жилки", 50, "zil.jpg", 2));

            items.Add(new Item("Шлейка", 1000, "shlei.jpg", 1));
            items.Add(new Item("Шлейка", 1000, "shlei.jpg", 2));
            
            items.Add(new Item("Мята", 300, "mite.jpg", 1));
            items.Add(new Item("Лакомства", 300, "lak.jpg", 2));

            items.Add(new Item("Корм", 150, "CD.jpg", 1));
            items.Add(new Item("Корм", 150, "KD.jpg", 2));

            items.Add(new Item("Игрушка", 500, "GC.jpg", 1));
            items.Add(new Item("Игрушка", 500, "GD.jpg", 2));
            //вызываем метод генерации интерфейса
            LoadItems();
            bascet.Content = $"Корзина ({MainWindow.Cost})";
        }
        public void LoadItems() {
            parent.Children.Clear(); // очищаем элемент parent
            foreach (Item item in items.FindAll(x => x.Category == id)) {
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
