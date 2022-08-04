using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Context.Configure.Entity;

public static class OwnerConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<Owner>()
            .HasIndex(o => o.Code)
            .IsUnique(true);

        builder.Entity<Owner>()
            .HasIndex(o => o.Document)
            .IsUnique(true);
    }
}