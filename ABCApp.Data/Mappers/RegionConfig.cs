using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Data.Mappers
{
    public class RegionConfig
    {
        public RegionConfig(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Master_Region");
            builder.Property(t => t.RegionCode).HasColumnType("char").HasMaxLength(3);
            builder.HasKey(t => t.RegionCode);            
            builder.Property(t => t.RegionName).HasMaxLength(255).IsRequired();
            builder.Property(t => t.CountryCode).HasColumnType("char").HasMaxLength(3).IsRequired();
            builder.HasMany(t => t.CityList).WithOne().HasForeignKey(t => t.RegionCode);
            builder.HasMany(t => t.OrdersList).WithOne().HasForeignKey(t => t.RegionCode).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
