using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Address;

namespace Wms.Core.Infrastructure.Mappings.AddressMapping;

public class ZoneMapping : IEntityTypeConfiguration<Zone>
{
    public void Configure(EntityTypeBuilder<Zone> builder)
    {
        builder.HasKey(z => z.Id);

        builder.Property(z => z.Deposit).IsRequired().HasMaxLength(4);
        builder.Property(z => z.Area).IsRequired().HasMaxLength(4);
        builder.Property(z => z.Status).HasConversion<int>();
        builder.Property(z => z.FirstComponent).IsRequired().HasMaxLength(4);
        builder.Property(z => z.SecondComponent).HasMaxLength(4);
        builder.Property(z => z.ThirdComponent).HasMaxLength(4);
        builder.Property(z => z.FourthComponent).HasMaxLength(4);
        builder.Property(z => z.FifthComponent).HasMaxLength(4);
        builder.Property(z => z.SixthComponent).HasMaxLength(4);
        builder.Property(z => z.AddressFormat).IsRequired().HasMaxLength(30);
        builder.Property(z => z.Dock);
        builder.Property(z => z.SingleBatch);
        builder.Property(z => z.SingleProduct);
        builder.Property(z => z.FixedPicking);
        builder.Property(z => z.DynamicReplacement);
        builder.Property(z => z.MinimumAndMaximumReplacement);

        /*Ef constraints*/
        builder.Property(z => z.Cd).IsRequired().HasMaxLength(3);
        builder.Property(z => z.TypeAddressCode).HasMaxLength(4);

        builder.ToTable("Zone");
    }
}