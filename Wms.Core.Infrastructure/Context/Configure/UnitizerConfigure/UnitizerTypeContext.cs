using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Unitizer;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Infrastructure.Context.Configure.UnitizerConfigure;

public static class UnitizerTypeConfiguration
{
    public static void ConfigureConstraints(ModelBuilder builder)
    {
        builder
            .Entity<UnitizerType>()
            .HasIndex(u => new { u.Code })
            .IsUnique(true);

        builder
            .Entity<UnitizerType>()
            .Property(u => u.LengthUnit)
            .HasConversion(u => u.ToString(), u => (SizeUnit)Enum.Parse(typeof(SizeUnit), u))
            .HasMaxLength(10)
            .HasColumnType("varchar");

        builder
            .Entity<UnitizerType>()
            .Property(u => u.WidthUnit)
            .HasConversion(u => u.ToString(), u => (SizeUnit)Enum.Parse(typeof(SizeUnit), u))
            .HasMaxLength(10)
            .HasColumnType("varchar");

        builder
            .Entity<UnitizerType>()
            .Property(u => u.HeightUnit)
            .HasConversion(u => u.ToString(), u => (SizeUnit)Enum.Parse(typeof(SizeUnit), u))
            .HasMaxLength(10)
            .HasColumnType("varchar");

        builder
            .Entity<UnitizerType>()
            .Property(u => u.WeightUnit)
            .HasConversion(u => u.ToString(), u => (WeightUnit)Enum.Parse(typeof(WeightUnit), u))
            .HasMaxLength(10)
            .HasColumnType("varchar");
    }
}