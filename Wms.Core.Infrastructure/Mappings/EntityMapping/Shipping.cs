using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Mappings.EntityMapping;

public class ShippingMapping : IEntityTypeConfiguration<Shipping>
{
    public void Configure(EntityTypeBuilder<Shipping> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Code).IsRequired().HasMaxLength(10);
        builder.Property(o => o.Name).HasMaxLength(200);
        builder.Property(o => o.Document).HasMaxLength(14);
        builder.Property(o => o.TypeDoc).HasConversion<int>();
        builder.Property(o => o.Status).HasConversion<int>().IsRequired();
        builder.Property(b => b.LastChangeDate);
        builder.Property(b => b.CreationDate);
    }
}
