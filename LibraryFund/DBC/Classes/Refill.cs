using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Classes
{
    public class Refill
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Staff {  get; set; }
        public int Library { get; set; }
        public string Literature { get; set; }
        public int Count { get; set; }
    }
}
