using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Infrastructure.Context.Configure.Warehouse;

public static class StockConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<Stock>()
            .HasIndex(s => new
            {
                s.Cd,
                s.OwnerCode,
                s.ProductCode,
                s.Deposit,
                s.Area,
                s.Address,
                s.NrUnitizer,
                s.Lot,
                s.ProductionDate,
                s.ExpirationDate
            })
            .IsUnique(true);

        builder.Entity<Stock>()
            .HasOne<Provider>()
            .WithMany()
            .HasForeignKey(s => s.Cd)
            .HasPrincipalKey(cd => cd.Code);

        builder.Entity<Stock>()
            .HasOne<StockAddress>()
            .WithMany()
            .HasForeignKey(s => new { s.Cd, s.Deposit, s.Area, s.Address })
            .HasPrincipalKey(z => new { z.Cd, z.Deposit, z.Area, z.Address });

        builder.Entity<Stock>()
            .HasOne<Owner>()
            .WithMany()
            .HasForeignKey(s => s.OwnerCode)
            .HasPrincipalKey(o => o.Code);

        builder.Entity<Stock>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => new { s.OwnerCode, s.ProductCode })
            .HasPrincipalKey(p => new { p.OwnerCode, p.Code });

        builder.Entity<Stock>()
        .HasOne<Unitizer>()
        .WithMany()
        .HasForeignKey(s => new { s.Cd, s.NrUnitizer })
        .HasPrincipalKey(p => new { p.Cd, p.NrUnitizer });
    }
}