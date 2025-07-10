using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Tabels
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        public Library(int id, string name, string adress, string city)
        {
            Id = id;
            Name = name;
            Adress = adress;
            City = city;
        }
    }
}
