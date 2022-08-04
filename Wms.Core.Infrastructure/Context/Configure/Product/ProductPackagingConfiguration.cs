using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Infrastructure.Context.Configure.ProductConfiguration;

public static class ProductPackagingConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<ProductPackaging>()
            .HasIndex(p => new { p.Cd, p.BarCode })
            .IsUnique(true);

        builder.Entity<ProductPackaging>()
            .HasIndex(p => new { p.Cd, p.OwnerCode, p.ProductCode, p.UnitizerType })
            .IsUnique(true);

        builder.Entity<ProductPackaging>()
            .HasOne<Provider>()
            .WithMany()
            .HasForeignKey(p => p.Cd)
            .HasPrincipalKey(cd => cd.Code);

        builder.Entity<ProductPackaging>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => new { p.OwnerCode, p.ProductCode })
            .HasPrincipalKey(p => new { p.OwnerCode, p.Code });

        builder.Entity<ProductPackaging>()
            .HasOne<UnitizerType>()
            .WithMany()
            .HasForeignKey(p => p.UnitizerType)
            .HasPrincipalKey(u => u.Code);
    }
}