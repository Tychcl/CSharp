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
using pr19.Classes;

namespace pr19.Elements
{
    /// <summary>
    /// Логика взаимодействия для cat.xaml
    /// </summary>
    public partial class cat : UserControl
    {
        int id;
        public cat(Classes.Category category)
        {
            InitializeComponent(); 
            if (category != null)
            {
                string gg = MainWindow.mainWindow.loc + "\\image\\" + category.Src;
                if (File.Exists(gg))
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/pr19;component/image/" + category.Src));
                else
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/pr19;component/image/background.png"));
                categoryName.Content = category.Name;
            }
            id = category.Id;
        }
        private void OpenCategory(object sender, MouseButtonEventArgs e)
        {
            
            MainWindow.ActiveCategory = Classes.Category.AllCategories().Find(x => x.Name == this.categoryName.Content.ToString());
            MainWindow.mainWindow.OpenPage(new Pages.Main(id));
        }
    }
}
