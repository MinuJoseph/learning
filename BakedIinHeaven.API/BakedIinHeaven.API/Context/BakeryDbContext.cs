using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakedInHeaven.API.Models;

namespace BakedInHeaven.API.Context
{
    public class BakeryDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        public DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=anna_bakery_db;Username=postgres;Password=exp@123");
    }
}
