using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Data.Mappers
{
    public class OrderListItemConfig
    {
        public OrderListItemConfig(EntityTypeBuilder<OrderListItem> builder)
        {
            builder.HasNoKey();
            builder.Property(t => t.CustomerName);
            builder.Property(t => t.DateOfSale);
            builder.Property(t => t.Country);
            builder.Property(t => t.Product);
            builder.Property(t => t.Quantity);
            builder.Property(t => t.Region);
            builder.Property(t => t.City);
            builder.Property(t => t.TotalSale).HasColumnType("decimal(18,2)");
        }
    }
}
