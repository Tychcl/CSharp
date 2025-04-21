using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pr29.Models;

namespace pr29.Classes
{
    public class UsersContext:DbContext
    {
        public DbSet<Users> Users { get; set; }

        public UsersContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Common.Config.ConnectionString, Common.Config.V);
        }
    }
}
