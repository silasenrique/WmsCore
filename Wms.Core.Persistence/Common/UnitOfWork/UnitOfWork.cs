using Wms.Core.Persistence.Configuration;

namespace Wms.Core.Persistence.Common.UnitOfWork;

internal sealed class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly ApplicationDbContext _dbContext;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}