using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr29.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Classes.UsersContext all = new Classes.UsersContext();
        public Main()
        {
            InitializeComponent();
            foreach(Models.Users i in all.Users)
            {
                Parent.Children.Add(new Pages.Users.Elements.Item(i,this));
            }
        }

        private void badd(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Users.Add(this));
        }
    }
}
