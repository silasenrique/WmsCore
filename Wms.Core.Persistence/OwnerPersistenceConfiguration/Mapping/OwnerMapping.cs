using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Owner;

namespace Wms.Core.Persistence.OwnerPersistenceConfiguration.Mapping;

public class OwnerMapping : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id);
        builder.Property(o => o.Code).IsRequired().HasMaxLength(20);
        builder.Property(o => o.Name).HasMaxLength(200);
        builder.Property(o => o.Document).HasMaxLength(14);

        // builder.Metadata.FindNavigation(nameof(Owner.Carriers))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        // builder.Metadata.FindNavigation(nameof(Owner.Suppliers))?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(Owner.Customers))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(c => c.Customers).AutoInclude();
    }
}