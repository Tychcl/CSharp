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

namespace pr16
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow = new MainWindow();
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Pages.Status());
            mainWindow = this;
        }
        public enum pages
        {
            Statement,
            Education,
            Status,
            Speciality,
            Passport,
            Contacts,
            Parents
        }
        public void OpenPage(pages _page)
        {
            if (_page == pages.Statement)
                frame.Navigate(new Pages.Statement());
            if (_page == pages.Education)
                frame.Navigate(new Pages.Education());
            if (_page == pages.Status)
                frame.Navigate(new Pages.Status());
            if (_page == pages.Speciality)
                frame.Navigate(new Pages.Speciality());
            if (_page == pages.Passport)
                frame.Navigate(new Pages.Passport());
            if (_page == pages.Contacts)
                frame.Navigate(new Pages.Contacts());
            if (_page == pages.Parents)
                frame.Navigate(new Pages.Parents());
        }
    }
}
