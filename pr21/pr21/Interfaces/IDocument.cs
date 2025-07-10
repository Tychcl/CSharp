using pr21.Classes;
using pr21.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr21.Interfaces
{
    internal interface IDocument
    {
        void Save(bool Update = false);
        List<DocumentContext> AllDocuments();
        void Delete();
    }
}
