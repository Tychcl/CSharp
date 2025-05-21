using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBC.Context
{
    public class Literature : DbContext
    {
        public DbSet<Literature> Literaturies { get; set; }
        public Literature()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(DB.con, DB.MySQL);
        }
    }
}
