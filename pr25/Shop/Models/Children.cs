
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Children : Shop
    {
        public int Age { get; set; }
        public int IdProduct { get; set; }

        public Children() { }
        public Children(int Id, int IdProduct, string Name, string Img, int Discount, int Price, int Age) : base(Id, Name, Price, Img, Discount)
        {
            this.Age = Age;
            this.IdProduct = IdProduct;
        }
    }
}
