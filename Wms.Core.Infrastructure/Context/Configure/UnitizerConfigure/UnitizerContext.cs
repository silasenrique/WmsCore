using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Address;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Unitizer;

namespace Wms.Core.Infrastructure.Context.Configure.UnitizerConfigure;

public static class UnitizerConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        //* Foreign Key com a StockAddress
        builder.Entity<Unitizer>()
            .HasOne<StockAddress>()
            .WithMany()
            .HasForeignKey(u => new { u.Cd, u.Deposit, u.Area, u.Address })
            .HasPrincipalKey(s => new { s.Cd, s.Deposit, s.Area, s.Address });

        //* Foreign Key com a UnitizerType
        builder.Entity<Unitizer>()
            .HasOne<UnitizerType>()
            .WithMany()
            .HasForeignKey(u => u.UnitizerType)
            .HasPrincipalKey(ut => ut.Code);

        //* Foreign Key com a DistributionCenter
        builder.Entity<Unitizer>()
            .HasOne<Provider>()
            .WithMany()
            .HasForeignKey(u => u.Cd)
            .HasPrincipalKey(c => c.Code);

        builder.Entity<Unitizer>()
            .HasIndex(u => new { u.Cd, u.NrUnitizer, u.UnitizerType })
            .IsUnique(true);
    }
}