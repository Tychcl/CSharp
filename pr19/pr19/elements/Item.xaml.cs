using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace pr19.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item(Classes.Item item)
        {
            InitializeComponent();
            if (item != null) {
                string gg = MainWindow.mainWindow.loc + "\\image\\" + item.Src;
                if (File.Exists(gg))
                    image.Source = new BitmapImage(new Uri(gg));
                else
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/pr19;component/image/background.png"));
                name.Content = item.Name;
                price.Content = item.Price;
            }
        }

        private void buy(object sender, RoutedEventArgs e)
        {

            float cost = float.Parse(countItem.Text) * float.Parse(price.Content.ToString());
            Pages.Main.main.AddCost(cost);
        }

        private void less(object sender, RoutedEventArgs e)
        {
            if(countItem.Text != null && int.Parse(countItem.Text)>0)
            {
                int count = int.Parse(countItem.Text);
                count--;
                countItem.Text = count.ToString();
            }
        }

        private void more(object sender, RoutedEventArgs e)
        {
            if (countItem.Text != null)
            {
                int count = int.Parse(countItem.Text);
                count++;
                countItem.Text = count.ToString();
            }
        }
    }
}
