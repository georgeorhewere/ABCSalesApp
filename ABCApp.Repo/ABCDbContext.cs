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
        public ABCDbContext(DbContextOptions<ABCDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);                            
            modelBuilder.ApplyConfiguration(new ProducConfig());
        }
    }
}
