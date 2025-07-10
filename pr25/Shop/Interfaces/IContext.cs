using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IContext
    {
        List<Object> All();
        void Save(bool Update = false);
        void Delete();
    }
}
