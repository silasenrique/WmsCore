using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Infrastructure.Mappings.AddressMapping;

public class TypeAddressMapping : IEntityTypeConfiguration<TypeAddress>
{
    public void Configure(EntityTypeBuilder<TypeAddress> builder)
    {
        builder.HasIndex(t => t.Id);

        builder.Property(t => t.Code).IsRequired().HasMaxLength(4);
        builder.Property(t => t.Weight);
        builder.Property(t => t.Height);
        builder.Property(t => t.Width);
        builder.Property(t => t.Length);
        builder.Property(t => t.ControlType).HasConversion<int>();
        builder.Property(t => t.WeightUnit).HasConversion<int>();
        builder.Property(t => t.HeightUnit).HasConversion<int>();
        builder.Property(t => t.WidthUnit).HasConversion<int>();
        builder.Property(t => t.LengthUnit).HasConversion<int>();
        builder.Property(t => t.Cd).IsRequired().HasMaxLength(4);

        builder.ToTable("TypeAddress");
    }
}