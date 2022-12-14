using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Context.Configure.Entity;

public static class ProviderConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<Provider>()
            .HasIndex(o => o.Code)
            .IsUnique(true);

        builder.Entity<Provider>()
            .HasIndex(o => o.Document)
            .IsUnique(true);
    }
}