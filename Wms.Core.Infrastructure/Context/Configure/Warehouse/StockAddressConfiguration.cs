using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Infrastructure.Context.Configure.Warehouse;

public static class StockAddressConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<StockAddress>()
            .HasIndex(s => new { s.Cd, s.BarCode })
            .IsUnique(true);

        builder.Entity<StockAddress>()
            .HasIndex(s => new { s.Cd, s.Deposit, s.Area, s.Address })
            .IsUnique(true);

        builder.Entity<StockAddress>()
            .HasOne<Provider>()
            .WithMany()
            .HasForeignKey(s => s.Cd)
            .HasPrincipalKey(cd => cd.Code);

        builder.Entity<StockAddress>()
            .HasOne<Zone>()
            .WithMany()
            .HasForeignKey(s => new { s.Cd, s.Deposit, s.Area })
            .HasPrincipalKey(z => new { z.Cd, z.Deposit, z.Area });

        builder.Entity<StockAddress>()
            .HasOne<Owner>()
            .WithMany()
            .HasForeignKey(s => s.OwnerCode)
            .HasPrincipalKey(o => o.Code);

        builder.Entity<StockAddress>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => new { s.OwnerCode, s.ProductCode })
            .HasPrincipalKey(p => new { p.OwnerCode, p.Code });

        builder.Entity<StockAddress>()
            .HasOne<TypeAddress>()
            .WithMany()
            .HasForeignKey(s => new { s.Cd, s.TypeAddress })
            .HasPrincipalKey(t => new { t.Cd, t.Code });
    }
}