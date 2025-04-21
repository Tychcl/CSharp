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

namespace pr29.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Classes.ClubsContext all = new Classes.ClubsContext();
        public Main()
        {
            InitializeComponent();
            foreach(Models.Clubs i in all.Clubs)
            {
                Parent.Children.Add(new Pages.Clubs.Elements.Item(i,this));
            }
        }

        private void badd(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Clubs.Add(this));
        }
    }
}
