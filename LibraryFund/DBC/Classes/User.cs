using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
