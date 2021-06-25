using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Data.Mappers
{
    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> builder)
        {
           
            builder.ToTable("Master_Product");
            builder.HasKey(t => t.ProductId);
            builder.Property(t => t.ProductName).HasMaxLength(255).IsRequired();
            builder.Property(t => t.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
        
    }
}
