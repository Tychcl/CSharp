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
using pr26.Context;
using System.Xml.Linq;

namespace pr26.Pages
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Page
    {
        public Ticket(string Out, string In = default, DateTime TimeOut = default, DateTime TimeIn = default)
        {
            InitializeComponent();
            MainWindow.main.Tickets = TicketsContext.All();
            if(MainWindow.main.Tickets == null)
            {
                return;
            }
            List<TicketsContext> asd = new List<TicketsContext>();

            //Если все поля заполнены
            if (!String.IsNullOrEmpty(Out) && !String.IsNullOrEmpty(In) && TimeOut != default && TimeIn != default)
            {
                MainWindow.main.Tickets = MainWindow.main.Tickets.FindAll(j => (j.From == Out && j.To == In && j.TimeOut.ToShortDateString() == TimeOut.ToShortDateString()) ||
                     (j.From == In && j.To == Out && j.TimeOut.ToString("dd/MM/yyyy") == TimeIn.ToString("dd/MM/yyyy"))).OrderBy(x => x.TimeOut).ToList();
            }

            //Если заполнено все кроме даты прилета
            if (!String.IsNullOrEmpty(Out) && !String.IsNullOrEmpty(In) && TimeOut != default && TimeIn == default)
            {
                MainWindow.main.Tickets = MainWindow.main.Tickets.FindAll(j => (j.From == Out && j.To == In && j.TimeOut.ToString("dd/MM/yyyy") == TimeOut.ToString("dd/MM/yyyy")));
            }

            //Если заполнено только место вылета и место прилета 
            if (!String.IsNullOrEmpty(Out) && !String.IsNullOrEmpty(In) && TimeOut == default && TimeIn == default)
            {
                MainWindow.main.Tickets = MainWindow.main.Tickets.FindAll(j => (j.From == Out && j.To == In));
            }

            //Если заполнено только место вылета
            if (!String.IsNullOrEmpty(Out) && String.IsNullOrEmpty(In) && TimeOut == default && TimeIn == default)
            {
                MainWindow.main.Tickets = MainWindow.main.Tickets.FindAll(j => (j.From == Out));
            }

            foreach (TicketsContext ticket in MainWindow.main.Tickets)
                parent.Children.Add(new Items.Ticket(ticket));
        }

        private void Exit(object sender, RoutedEventArgs e) =>
            MainWindow.main.OpenPage(new Pages.Main());
    }
}
