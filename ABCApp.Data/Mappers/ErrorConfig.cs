using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCApp.Data.Mappers
{
    public class ErrorConfig
    {
        public ErrorConfig(EntityTypeBuilder<DbError> builder)
        {
            builder.ToTable("Errors");
            builder.HasKey(t => t.ErrorId);
            builder.Property(t => t.ErrorBy).IsRequired();
            builder.Property(t => t.ErrorDetail).IsRequired();
            builder.Property(t => t.ErrorOn).IsRequired();            
        }
    }
}
