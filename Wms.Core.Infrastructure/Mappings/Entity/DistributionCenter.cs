using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Mappings.Entity;

public class DistributionCenterMapping : IEntityTypeConfiguration<DistributionCenter>
{
    public void Configure(EntityTypeBuilder<DistributionCenter> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Code).HasMaxLength(10).IsRequired();
        builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
        builder.Property(b => b.Document).HasMaxLength(14);
    }
}