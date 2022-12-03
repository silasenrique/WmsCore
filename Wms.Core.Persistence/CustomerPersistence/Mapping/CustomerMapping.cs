using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Owner.Models;

namespace Wms.Core.Persistence.CustomerPersistence.Mapping;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id);
        builder.Property(o => o.Code);
        builder.Property(o => o.Name);
        builder.Property(o => o.Document);

        builder.Metadata.FindNavigation(nameof(Customer.Owners))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(c => c.Owners).AutoInclude();
    }
}