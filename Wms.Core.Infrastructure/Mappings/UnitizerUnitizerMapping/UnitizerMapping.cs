using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Unitizer;

namespace Wms.Core.Infrastructure.Mappings.UnitizerUnitizerMapping;

public class UnitizerMapping : IEntityTypeConfiguration<Unitizer>
{
    public void Configure(EntityTypeBuilder<Unitizer> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.NrUnitizer).HasMaxLength(7);
        builder.Property(u => u.InMotion);
        builder.Property(u => u.UnitizerType).HasConversion<int>();

        /*Ef constraints*/
        builder.Property(u => u.Deposit).IsRequired();
        builder.Property(u => u.Area).IsRequired();
        builder.Property(u => u.Address).IsRequired();
        builder.Property(u => u.UnitizerType).IsRequired();
        builder.Property(u => u.Cd).IsRequired();

        builder.ToTable("Unitizer");
    }
}