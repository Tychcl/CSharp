using pr26.Classes;
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
using MySql;

namespace pr26
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main;
        public List<Ticket> Tickets = new List<Ticket>();
        public MainWindow()
        {
            InitializeComponent();
            main = this;
            frame.Navigate(new Pages.Main());
        }

        public void LoadTickets()
        {
            Tickets.Clear();
            string con = "srever=localhost;port=3306;database=pr26;uid=root;pwd=root";
            
        }
    }
}
