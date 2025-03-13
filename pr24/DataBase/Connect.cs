using DataBase.Tabels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Connect
    {
        public static readonly string DB = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Directory.GetCurrentDirectory() + "\\DB.accdb";
        public enum tabels
        {
            Fond, Library, Refill, Staff, Type
        }
        public List<Fond> Fonds = new List<Fond>();
        public List<Library> Librares = new List<Library>();
        public List<Refill> Refills = new List<Refill>();
        public List<Staff> Staffs = new List<Staff>();
        public List<Tabels.Type> Types = new List<Tabels.Type>();
    }
}
