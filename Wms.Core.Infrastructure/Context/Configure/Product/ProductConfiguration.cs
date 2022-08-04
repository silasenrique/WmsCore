using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Product;

namespace Wms.Core.Infrastructure.Context.Configure.ProductConfiguration;

public static class ProductConfigurations
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasOne<Owner>()
            .WithMany()
            .HasForeignKey(p => p.OwnerCode)
            .HasPrincipalKey(o => o.Code);

        builder.Entity<Product>()
            .HasIndex(p => new { p.OwnerCode, InternalCode = p.Code })
            .IsUnique(true);
    }
}