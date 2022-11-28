using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Owner.Relationship;

namespace Wms.Core.Persistence.CustomerOwnerPersistence.Mapping;

public class CustomerOwnerMapping : IEntityTypeConfiguration<CustomerOwner>
{
    public void Configure(EntityTypeBuilder<CustomerOwner> builder)
    {
        builder.HasKey(x => new { x.CustomerId, x.OwnerId });

        builder.Property(o => o.OwnerId).IsRequired().HasColumnName("owner_id");
        builder.Property(o => o.CustomerId).IsRequired().HasColumnName("customer_id");

        builder.Metadata.FindNavigation(nameof(CustomerOwner.Customer))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(CustomerOwner.Owner))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(c => c.Customer).AutoInclude();

        builder.ToTable("customer_owner");
    }
}