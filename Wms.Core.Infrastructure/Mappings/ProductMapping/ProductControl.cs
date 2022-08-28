using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Product;

namespace Wms.Core.Infrastructure.Mappings.ProductMapping;

public class ProductControlMapping : IEntityTypeConfiguration<ProductControl>
{
    public void Configure(EntityTypeBuilder<ProductControl> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Lot);
        builder.Property(p => p.ExpirationDate);
        builder.Property(p => p.ProductionDate);
        builder.Property(p => p.DriveUnit).HasMaxLength(4);
        builder.Property(p => p.Cd).HasMaxLength(4).IsRequired();
        builder.Property(p => p.OwnerCode).HasMaxLength(20).IsRequired();
        builder.Property(p => p.ProductCode).HasMaxLength(20).IsRequired();
        builder.Property(b => b.LastChangeDate);
        builder.Property(b => b.CreationDate);
    }
}