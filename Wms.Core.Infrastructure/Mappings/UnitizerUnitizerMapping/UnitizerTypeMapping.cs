using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Unitizer;

namespace Wms.Core.Infrastructure.Mappings.UnitizerUnitizerMapping;

public class UnitizerTypeMapping : IEntityTypeConfiguration<UnitizerType>
{
    public void Configure(EntityTypeBuilder<UnitizerType> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Code).IsRequired().HasMaxLength(4);
        builder.Property(u => u.Description).HasMaxLength(200);
        builder.Property(u => u.MaximumWeight);
        builder.Property(u => u.WeightUnit);
        builder.Property(u => u.Height);
        builder.Property(u => u.HeightUnit);
        builder.Property(u => u.Width);
        builder.Property(u => u.WidthUnit);
        builder.Property(u => u.Length);
        builder.Property(u => u.LengthUnit);

        builder.ToTable("UnitizerType");
    }
}