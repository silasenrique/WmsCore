using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Domain.Entities.Product;
using Wms.Core.Domain.Entities.Warehouse;
using Wms.Core.Infrastructure.Context.Configure.Entity;
using Wms.Core.Infrastructure.Context.Configure.ProductConfiguration;
using Wms.Core.Infrastructure.Context.Configure.Warehouse;

namespace Wms.Core.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    //* Entity
    public DbSet<Owner>? Owner { get; set; }
    public DbSet<Shipping>? Shipping { get; set; }
    public DbSet<Provider>? Provider { get; set; }
    public DbSet<DistributionCenter>? DistributionCenter { get; set; }

    //* Warehouse
    public DbSet<Stock>? Stock { get; set; }
    public DbSet<Zone>? Zone { get; set; }
    public DbSet<Unitizer>? Unitizer { get; set; }
    public DbSet<StockAddress>? StockAddresses { get; set; }
    public DbSet<TypeAddress>? TypeAddress { get; set; }

    //* Product
    public DbSet<Product>? Product { get; set; }
    public DbSet<ProductPackaging>? ProductPackaging { get; set; }
    public DbSet<ProductControl>? ProductControl { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //* Entity
        OwnerConfiguration.ConfigureConstraints(modelBuilder);
        ShippingConfiguration.ConfigureConstraints(modelBuilder);
        ProviderConfiguration.ConfigureConstraints(modelBuilder);
        DistributionCenterConfiguration.ConfigureConstraints(modelBuilder);

        //* Product
        ProductConfigurations.ConfigureConstraints(modelBuilder);
        ProductPackagingConfiguration.ConfigureConstraints(modelBuilder);
        ProductControlConfiguration.ConfigureConstraints(modelBuilder);

        //* Warehouse
        ZoneConfiguration.ConfigureConstraints(modelBuilder);
        UnitizerConfiguration.ConfigureConstraints(modelBuilder);
        TypeAddressConfiguration.ConfigureConstraints(modelBuilder);
        StockAddressConfiguration.ConfigureConstraints(modelBuilder);
        StockConfiguration.ConfigureConstraints(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
}
