using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Tabels
{
    public class Refill
    {
        public int Id { get; set; }
        public int Fond {  get; set; }
        public int Staff { get; set; }
        public int Type { get; set; }
        public string DateRefill { get; set; }
        public string Source { get; set; }
        public string Publisher { get; set; }
        public string DatePublication { get; set; }
        public int Count { get; set; }

        public Refill(int id, int fond, int staff, int type, string daterefill, string source, string publisher, string datepublication, int count)
        {
            Id = id;
            Fond = fond;
            Staff = staff;
            Type = type;
            DateRefill = daterefill;
            Source = source;
            Publisher = publisher;
            DatePublication = datepublication;
            Count = count;
        }
    }
}
