using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBC.Context
{
    public class Refill : DbContext
    {
        public DbSet<Refill> Refills { get; set; }
        public Refill()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(DB.con, DB.MySQL);
        }
    }
}
