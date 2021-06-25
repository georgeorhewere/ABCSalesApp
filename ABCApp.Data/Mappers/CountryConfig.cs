using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Data.Mappers
{
    public class CountryConfig
    {
        public CountryConfig(EntityTypeBuilder<Country> builder)
        {

            builder.ToTable("Master_Country");
            builder.Property(t => t.CountryCode).HasColumnType("char").HasMaxLength(3);
            builder.HasKey(t => t.CountryCode);            
            builder.Property(t => t.CountryName).HasMaxLength(255).IsRequired();
            builder.HasMany(t => t.RegionList).WithOne().HasForeignKey(t => t.CountryCode);
            builder.HasMany(t => t.OrdersList).WithOne().HasForeignKey(t => t.CountryCode).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
