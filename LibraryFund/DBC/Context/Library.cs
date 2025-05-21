using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBC.Context
{
    public class Library : DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public Library()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(DB.con, DB.MySQL);
        }
    }
}
