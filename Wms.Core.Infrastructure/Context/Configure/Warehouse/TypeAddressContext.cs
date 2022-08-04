using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Warehouse;

namespace Wms.Core.Infrastructure.Context.Configure.Warehouse;

public static class TypeAddressConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<TypeAddress>()
            .HasIndex(t => new { t.Cd, t.Code })
            .IsUnique(true);

        builder.Entity<TypeAddress>()
            .HasOne<Provider>()
            .WithMany()
            .HasForeignKey(t => t.Cd)
            .HasPrincipalKey(cd => cd.Code);
    }
}