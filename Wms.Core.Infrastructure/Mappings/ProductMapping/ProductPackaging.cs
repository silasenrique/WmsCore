using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Product;

namespace Wms.Core.Infrastructure.Mappings.ProductMapping;

public class ProductPackagingMapping : IEntityTypeConfiguration<ProductPackaging>
{
    public void Configure(EntityTypeBuilder<ProductPackaging> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.BarCode).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Quantity).IsRequired();
        builder.Property(p => p.MaximumWeight);
        builder.Property(p => p.WeightUnit);
        builder.Property(p => p.Height);
        builder.Property(p => p.HeightUnit);
        builder.Property(p => p.Width);
        builder.Property(p => p.WidthUnit);
        builder.Property(p => p.Length);
        builder.Property(p => p.LengthUnit);
        builder.Property(p => p.Cd).HasMaxLength(4).IsRequired();
        builder.Property(p => p.OwnerCode).HasMaxLength(20).IsRequired();
        builder.Property(p => p.ProductCode).HasMaxLength(20).IsRequired();
        builder.Property(p => p.UnitizerType).HasMaxLength(4).IsRequired();
        builder.Property(b => b.LastChangeDate);
        builder.Property(b => b.CreationDate);
    }
}