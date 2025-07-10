using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr19.Classes
{
    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Src { get; set; }
        public int Category { get; set; }
        public Item(string Name, int Price, string Src, int Category)
        {
            this.Name = Name;
            this.Price = Price;
            this.Src = Src;
            this.Category = Category;
        }
    }
}
