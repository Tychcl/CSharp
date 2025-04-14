using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr26.Classes
{
    public class Ticket
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Price { get; set; }
        public string TimeOut { get; set; }
        public string TimeIn { get; set; }

        public Ticket() { }
        public Ticket(int IdTicket, string from, string to, int Price, string TimeOut, string TimeIn)
        {
            this.Id = IdTicket;
            this.From = from;
            this.To = to;
            this.Price = Price;
            this.TimeOut = TimeOut;
            this.TimeIn = TimeIn;
        }
    }
}
