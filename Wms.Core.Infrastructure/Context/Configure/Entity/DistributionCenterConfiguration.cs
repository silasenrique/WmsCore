using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Infrastructure.Context.Configure.Entity;

public static class DistributionCenterConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder.Entity<DistributionCenter>()
            .HasIndex(o => o.Code)
            .IsUnique(true);

        builder.Entity<DistributionCenter>()
            .HasIndex(o => o.Document)
            .IsUnique(true);
    }
}