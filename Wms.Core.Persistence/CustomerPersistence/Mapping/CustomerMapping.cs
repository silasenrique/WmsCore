using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Owner.Models;

namespace Wms.Core.Persistence.CustomerPersistence.Mapping;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("id");
        builder.Property(o => o.Code).IsRequired().HasMaxLength(20).HasColumnName("code");
        builder.Property(o => o.Name).HasMaxLength(200).HasColumnName("name");
        builder.Property(o => o.Document).HasMaxLength(14).HasColumnName("document");

        builder.Metadata.FindNavigation(nameof(Customer.Owners))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(c => c.Owners).AutoInclude();

        builder.ToTable("customer");
    }
}