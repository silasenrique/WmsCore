using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Address;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Inventory;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Domain.Entities.Unitizer;

namespace Wms.Core.Infrastructure.Context.Configure.Warehouse;

public static class StockConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<Inventory>()
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

        builder.Entity<Inventory>()
            .HasOne<Provider>()
            .WithMany()
            .HasForeignKey(s => s.Cd)
            .HasPrincipalKey(cd => cd.Code);

        builder.Entity<Inventory>()
            .HasOne<StockAddress>()
            .WithMany()
            .HasForeignKey(s => new { s.Cd, s.Deposit, s.Area, s.Address })
            .HasPrincipalKey(z => new { z.Cd, z.Deposit, z.Area, z.Address });

        builder.Entity<Inventory>()
            .HasOne<Owner>()
            .WithMany()
            .HasForeignKey(s => s.OwnerCode)
            .HasPrincipalKey(o => o.Code);

        builder.Entity<Inventory>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => new { s.OwnerCode, s.ProductCode })
            .HasPrincipalKey(p => new { p.OwnerCode, p.Code });

        builder.Entity<Inventory>()
        .HasOne<Unitizer>()
        .WithMany()
        .HasForeignKey(s => new { s.Cd, s.NrUnitizer })
        .HasPrincipalKey(p => new { p.Cd, p.NrUnitizer });
    }
}