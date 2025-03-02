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
using pr19.Classes;

namespace pr19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static float Cost = 0;
        public static MainWindow mainWindow = new MainWindow();
        public static Category ActiveCategory;
        public string loc;
        public MainWindow()
        {
            InitializeComponent();

            //открываем страницу
            mainWindow = this;
            loc = System.IO.Directory.GetCurrentDirectory();
            OpenPage(new Pages.Category());


        }
        public void OpenPage(Page page)
        {
            frame.Navigate(page);
        }
    }
}
