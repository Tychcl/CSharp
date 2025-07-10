using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Tabels
{
    public class Fond
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Library {  get; set; }
        public int Books { get; set; }
        public int Paper { get; set; }
        public int Magazine { get; set; }
        public int Collection { get; set; }
        public int Dissertation { get; set; }
        public int Report {  get; set; }

        public Fond(int id, string name, int library, int books,int paper,int magazine, int collection, int dissertation, int report)
        {
            Id = id;
            Name = name;
            Library = library;
            Books = books;
            Paper = paper;
            Magazine = magazine;
            Collection = collection;
            Dissertation = dissertation;
            Report = report;
        }
    }
}
