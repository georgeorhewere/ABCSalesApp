using ABCApp.Data;
using ABCApp.Data.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Repo
{
    public class ABCDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DbError> Errors { get; set; }
        public ABCDbContext(DbContextOptions<ABCDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            new ProductConfig(modelBuilder.Entity<Product>());
            new OrderConfig(modelBuilder.Entity<Order>());
            new CountryConfig(modelBuilder.Entity<Country>());
            new RegionConfig(modelBuilder.Entity<Region>());
            new CityConfig(modelBuilder.Entity<City>());
            new ErrorConfig(modelBuilder.Entity<DbError>());
        }
        
        
    }
}
