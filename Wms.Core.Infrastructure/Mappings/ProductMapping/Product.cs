using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Product;

namespace Wms.Core.Infrastructure.Mappings.ProductMapping;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(o => o.OwnerCode).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Code).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Description).HasMaxLength(200);
        builder.Property(p => p.Status).IsRequired().HasConversion<int>();
        builder.Property(p => p.LastChangeDate);
        builder.Property(p => p.CreationDate);
    }
}