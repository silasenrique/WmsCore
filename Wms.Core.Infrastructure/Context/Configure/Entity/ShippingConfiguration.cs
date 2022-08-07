using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Context.Configure.Entity;

public static class ShippingConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<Shipping>()
            .HasIndex(o => o.Code)
            .IsUnique(true);

        builder.Entity<Shipping>()
            .HasIndex(o => o.Document)
            .IsUnique(true);
    }
}