using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Mappings.EntityMapping;

public class OwnerMapping : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Code).IsRequired().HasMaxLength(20);
        builder.Property(o => o.Name).HasMaxLength(200);
        builder.Property(o => o.Document).HasMaxLength(14);
        builder.Property(o => o.TypeDoc).HasConversion<int>();
        builder.Property(o => o.Status).HasConversion<int>().IsRequired();
    }
}
