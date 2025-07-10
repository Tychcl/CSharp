using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    class Sport : Shop
    {
        public int Size { get; set; }
        public int IdProduct { get; set; }
        public Sport() { }
        public Sport(int Id, string Name, int Price, string Img, int Discount, int Size) : base(Id, Name, Price, Img, Discount)
        {
            this.Size = Size;
        }
    }
}
