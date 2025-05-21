using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBC.Context
{
    public class LiteratureType : DbContext
    {
        public DbSet<LiteratureType> LiteratureTypes { get; set; }
        public LiteratureType()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(DB.con, DB.MySQL);
        }
    }
}
