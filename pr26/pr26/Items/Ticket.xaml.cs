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
using pr26.Context;

namespace pr26.Items
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : UserControl
    {
        public Ticket(TicketsContext ticket)
        {
            InitializeComponent();
            from.Content = ticket.From;
            to.Content = ticket.To;
            ttime.Content = ticket.TimeIn.ToString("t");
            ftime.Content = ticket.TimeOut.ToString("t");
            fdate.Content = ticket.TimeOut.ToString("D");
            tdate.Content = ticket.TimeIn.ToString("D");
            path.Content = ticket.TimeIn.Subtract(ticket.TimeOut).Hours.ToString() + ":" + ticket.TimeIn.Subtract(ticket.TimeOut).Minutes.ToString();
            price.Content = ticket.Price.ToString();
        }
    }
}
