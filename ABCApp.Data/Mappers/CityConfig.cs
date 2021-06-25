using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Data.Mappers
{
    public class CityConfig
    {
        public CityConfig(EntityTypeBuilder<City> builder)
        {

            builder.ToTable("Master_City");
            builder.HasKey(t => t.CityCode);
            builder.Property(t => t.RegionCode).HasColumnType("char").HasMaxLength(3).IsRequired();
            builder.Property(t => t.CityName).HasMaxLength(255).IsRequired();
            builder.HasMany(t => t.OrdersList).WithOne().HasForeignKey(t => t.CityCode).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
