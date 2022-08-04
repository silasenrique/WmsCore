using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Infrastructure.Context.Configure.Warehouse;

public static class ZoneConfiguration
{
    public static void ConfigureConstraints(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Zone>()
            .HasOne<Provider>()
            .WithMany()
            .HasForeignKey(z => z.Cd)
            .HasPrincipalKey(d => d.Code);

        modelBuilder.Entity<Zone>()
            .HasIndex(z => new { z.Cd, z.Deposit, z.Area })
            .IsUnique(true);
    }
}