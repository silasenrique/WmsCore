using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Infrastructure.Mappings.Warehouse;

public class StockMapping : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.ExpirationDate)
            .HasMaxLength(10);

        builder.Property(s => s.ProductionDate)
            .HasMaxLength(10);

        builder.Property(s => s.Blocked);

        builder.Property(s => s.BlockingReason)
            .HasConversion<int>();

        builder.Property(s => s.AvailableQuantity);

        builder.Property(s => s.ReservedQuantity);

        builder.Property(s => s.QuantityInCirculation);

        builder.Property(s => s.Lot)
            .HasMaxLength(25);

        builder.ToTable("Stock");
    }
}