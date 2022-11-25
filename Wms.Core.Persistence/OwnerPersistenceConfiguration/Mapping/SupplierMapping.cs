using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Owner.Models;

namespace Wms.Core.Persistence.OwnerPersistenceConfiguration.Mapping;

public class SupplierMapping : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Code).IsRequired().HasMaxLength(20);
        builder.Property(o => o.Name).HasMaxLength(200);
        builder.Property(o => o.Document).HasMaxLength(14);
    }
}