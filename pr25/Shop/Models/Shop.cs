using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Img { get; set; }
        public int Discount { get; set; }

        public Shop() { }
        public Shop(int Id, string Name, int Price, string Img, int Discount)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Img = Img;
            this.Discount = Discount;
        }
    }
}
