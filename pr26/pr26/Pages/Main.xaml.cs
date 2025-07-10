using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace pr26.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }


        private void exit(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Close();
        }

        private void search(object sender, RoutedEventArgs e)
        {
            if (from.Text == default)
            {
                MessageBox.Show("Укажите место вылета");
                return;
            }
            if (TimeIn.SelectedDate != null && TimeOut.SelectedDate != null && !String.IsNullOrEmpty(from.Text) && !String.IsNullOrEmpty(to.Text))
                MainWindow.main.OpenPage(new Pages.Ticket(from.Text, to.Text, TimeOut.SelectedDate.Value, TimeIn.SelectedDate.Value));
            if (TimeIn.SelectedDate == null && TimeOut.SelectedDate != null && !String.IsNullOrEmpty(from.Text) && !String.IsNullOrEmpty(to.Text))
                MainWindow.main.OpenPage(new Pages.Ticket(from.Text, to.Text, TimeOut.SelectedDate.Value));
            if (TimeIn.SelectedDate == null && TimeOut.SelectedDate == null && !String.IsNullOrEmpty(from.Text) && !String.IsNullOrEmpty(to.Text))
                MainWindow.main.OpenPage(new Pages.Ticket(from.Text, to.Text));
            if (TimeIn.SelectedDate == null && TimeOut.SelectedDate == null && !String.IsNullOrEmpty(from.Text) && String.IsNullOrEmpty(to.Text))
                MainWindow.main.OpenPage(new Pages.Ticket(from.Text));
        }
    }
}
