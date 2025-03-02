using pr19.Classes;
using System;
using System.Collections.Generic;
  using pr19.Elements;
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

namespace pr19.Pages
{
    /// <summary>
    /// Логика взаимодействия для Category.xaml
    /// </summary>
    public partial class Category : Page
    {
        public List<Classes.Category> category = Classes.Category.AllCategories();
        
        public Category()
        {
            InitializeComponent();
            LoadItems();
        }
        public void LoadItems()
        {
            parent.Children.Clear();
            foreach (Classes.Category category in category)
                parent.Children.Add(new Elements.cat(category));
        }
    }
}
