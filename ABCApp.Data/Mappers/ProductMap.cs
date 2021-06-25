using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Data.Mappers
{
    public class ProducConfig : IEntityTypeConfiguration<Product>
    {        
        public void Configure(EntityTypeBuilder<Product> builder)
        {
                builder.HasKey(t => t.ProductId);
                builder.Property(t => t.ProductName).IsRequired();
                builder.Property(t => t.Price).IsRequired();
        }
    }
}
