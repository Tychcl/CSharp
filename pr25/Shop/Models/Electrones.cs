using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    class Electrones : Models.Shop
    {
        public int BatteryCapacity { get; set; }
        public int DriveSpeed { get; set; }
        public Electrones(int Id, string Name, int Price, int BatteryCapacity, int DriveSpeed, string Img, int Discount) : base(Id, Name, Price, Img, Discount)
        {
            this.BatteryCapacity = BatteryCapacity;
            this.DriveSpeed = DriveSpeed;
        }
    }
}
