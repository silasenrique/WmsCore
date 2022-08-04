using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Infrastructure.Mappings.Warehouse;

public class StockAddressMapping : IEntityTypeConfiguration<StockAddress>
{
    public void Configure(EntityTypeBuilder<StockAddress> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.OccupationStatus);
        builder.Property(s => s.OccupancyPercentage);
        builder.Property(s => s.Address).HasMaxLength(30).IsRequired();
        builder.Property(s => s.FirstComponent).HasMaxLength(4).IsRequired();
        builder.Property(s => s.SecondComponent).HasMaxLength(4).IsRequired();
        builder.Property(s => s.ThirdComponent).HasMaxLength(4).IsRequired();
        builder.Property(s => s.FourthComponent).HasMaxLength(4).IsRequired();
        builder.Property(s => s.FifthComponent).HasMaxLength(4).IsRequired();
        builder.Property(s => s.SixthComponent).HasMaxLength(4).IsRequired();
        builder.Property(s => s.BarCode).HasMaxLength(24).IsRequired();
        builder.Property(s => s.SingleProduct);
        builder.Property(s => s.SingleBatch);
        builder.Property(s => s.FixedPicking);
        builder.Property(s => s.MinimumAmount);
        builder.Property(s => s.MaximumAmount);
        builder.Property(s => s.Cd).HasMaxLength(4).IsRequired();
        builder.Property(s => s.Deposit).HasMaxLength(4).IsRequired();
        builder.Property(s => s.Area).HasMaxLength(4).IsRequired();
        builder.Property(s => s.OwnerCode).HasMaxLength(4).IsRequired();
        builder.Property(s => s.ProductCode).HasMaxLength(4).IsRequired();
        builder.Property(s => s.TypeAddress).HasMaxLength(4).IsRequired();

        builder.ToTable("StockAddress");
    }
}