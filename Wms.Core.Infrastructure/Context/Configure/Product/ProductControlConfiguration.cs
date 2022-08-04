using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Infrastructure.Context.Configure.ProductConfiguration;

public static class ProductControlConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<ProductControl>()
            .HasOne<Provider>()
            .WithMany()
            .HasForeignKey(p => p.Cd)
            .HasPrincipalKey(cd => cd.Code);

        builder.Entity<ProductControl>()
            .HasOne<ProductPackaging>()
            .WithMany()
            .HasForeignKey(p => new { p.Cd, p.OwnerCode, p.ProductCode, p.DriveUnit })
            .HasPrincipalKey(u => new { u.Cd, u.OwnerCode, u.ProductCode, u.UnitizerType });

        builder.Entity<ProductControl>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => new { p.OwnerCode, p.ProductCode })
            .HasPrincipalKey(p => new { p.OwnerCode, p.Code });

        builder.Entity<ProductControl>()
            .HasIndex(p => new { p.Cd, p.OwnerCode, p.ProductCode })
            .IsUnique(true);
    }
}