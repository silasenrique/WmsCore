using Microsoft.EntityFrameworkCore;
using Wms.Core.Domain.Owner;
using Wms.Core.Domain.Owner.Models;
using Wms.Core.Domain.Owner.Relationship;
using Wms.Core.Persistence.CustomerOwnerPersistence.Mapping;
using Wms.Core.Persistence.CustomerPersistence.Mapping;
using Wms.Core.Persistence.OwnerPersistenceConfiguration.Mapping;

namespace Wms.Core.Persistence.Configuration;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Owner> Owner { get; set; } = null!;
    public DbSet<Customer> Customer { get; set; } = null!;
    // public DbSet<ShippingCompany> ShippingCompany { get; set; } = null!;
    // public DbSet<Supplier> Supplier { get; set; } = null!;
    public DbSet<CustomerOwner> CustomerOwner { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OwnerMapping());
        modelBuilder.ApplyConfiguration(new CustomerMapping());
        modelBuilder.ApplyConfiguration(new CustomerOwnerMapping());

        base.OnModelCreating(modelBuilder);
    }
}