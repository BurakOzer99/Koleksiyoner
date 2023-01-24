using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MertKoleksiyoner.Models.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("carCollection3") { }
        public DbSet<Araba> Araba { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

    }
}