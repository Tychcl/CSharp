using Int.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.Interfaces
{
    public interface IUsers
    {
        void All(out List<Users> Users);
    }
}
