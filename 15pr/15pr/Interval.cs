using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15pr
{
    public class Interval
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public Interval(int Id, string Time)
        {
            this.Id = Id;
            this.Time = Time;
        }
    }
}
