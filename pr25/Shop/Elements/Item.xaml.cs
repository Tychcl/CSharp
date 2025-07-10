using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Shop.Models;
using System.Xml.Serialization;
using Shop.Classes;

namespace Shop.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item(object ItemData)
        {
            InitializeComponent();

            var ShopData = ItemData as Models.Shop;
            tb_Name.Content = ShopData.Name;
            tb_price.Content = $"Цена: {ShopData.Price}";
            if (ShopData.Discount != 0)
            {
                tb_priceDiscount.Content = $"Скидка({ShopData.Discount}%): {ShopData.Price - ShopData.Price / 100 * ShopData.Discount}";
                tb_priceDiscount.Visibility = Visibility.Visible;
            }
            if (ShopData.Img != null)
                try
                {
                    img.Source = new BitmapImage(new Uri(ShopData.Img, UriKind.Absolute));
                }
                catch 
                {
                    img.Source = new BitmapImage(new Uri(MainWindow.main.local+"\\Images\\e.png", UriKind.Absolute));
                }
                


            if (ItemData is Children shop)
                tb_Characteristic.Content = "Возраст: " + shop.Age;
            if (ItemData is SportContext sport)
                tb_Characteristic.Content = "Размер: " + sport.Size;

        }
    }
}
