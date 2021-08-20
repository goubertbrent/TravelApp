using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAppBackend.Data.Mapping;
using TravelAppBackend.Models;

namespace TravelAppBackend.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ItemLine> ItemLines { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new JourneyConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemLineConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        }
    }
}
