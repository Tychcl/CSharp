using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Classes
{
    public class Literature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public int Type { get; set; }
    }
}
