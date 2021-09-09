using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Data.Mappers
{
    public class OrderConfig
    {
        public OrderConfig(EntityTypeBuilder<Order> builder)
        {

            builder.ToTable("Orders");
            builder.HasKey(t => t.OrderId);
            builder.Property(t => t.CustomerName).HasMaxLength(255).IsRequired();
            builder.Property(t => t.DateOfSale).IsRequired();
            builder.Property(t => t.CountryId).IsRequired();
            builder.Property(t => t.CityCode).IsRequired();
            builder.Property(t => t.Quantity).IsRequired();
            builder.Property(t => t.RegionId).IsRequired();
            builder.Property(t => t.ProductId).IsRequired();
            builder.Property(t => t.OrderTotal).HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.HasIndex(t => new {t.DateOfSale, t.CountryId, t.RegionId, t.CityCode });


        }
    }
}
