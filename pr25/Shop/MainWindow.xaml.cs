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

namespace Shop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<object> allItems = new List<object>();
        public readonly string local = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\x64\\Debug","");
        public static MainWindow main;

        public MainWindow()
        {
            allItems.AddRange(new Classes.ChildrenContext().All());
            allItems.AddRange(new Classes.SportContext().All());
            InitializeComponent();
            main = this;
            CreateUI();
        }
        public void CreateUI()
        {
            foreach (object Item in allItems)
                parent.Children.Add(new Elements.Item(Item));
        }

        //private void SearchBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    parent.Children.Clear();
        //    string search = Search.Text;
        //    foreach (object Item in allItems)
        //    {
        //        if (Item is Models.Electrones ElectronicsData)
        //            if (Convert.ToString(ElectronicsData.BatteryCapacity).Contains(search) || Convert.ToString(ElectronicsData.DriveSpeed).Contains(search))
        //                parent.Children.Add(new Elements.Item(Item));
        //        if (Item is Models.Children ChildrenData)
        //            if (Convert.ToString(ChildrenData.Age).Contains(search) || ChildrenData.Name.Contains(search))
        //                parent.Children.Add(new Elements.Item(Item));
        //        if (Item is Models.Sport SportData)
        //            if (Convert.ToString(SportData.Size).Contains(search))
        //                parent.Children.Add(new Elements.Item(Item));
        //    }
        //    if (parent.Children.Count == 0)
        //        MessageBox.Show("Товаров по запросу не найдено");
        //}
    }
}
