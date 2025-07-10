using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassConnection;

namespace check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Connection.tabels.users} {Connection.tabels.users.ToString()}");
            Console.ReadLine();
        }
    }
}
