using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Wms.Core.Persistence.Configuration;

namespace Wms.Core.Persistence.Common.Repository;

public abstract class GenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public void Create(TEntity objectToCreate)
    {
        _dbSet.Add(objectToCreate);
    }

    public void Update(TEntity objectToChange)
    {
        _dbSet.Update(objectToChange);
    }

    public void Delete(TEntity objectToDelete)
    {
        _dbSet.Remove(objectToDelete);
    }

    public IEnumerable<TEntity>? Get(Expression<Func<TEntity, bool>> filter)
    {
        return _dbSet.Where(filter).AsNoTracking().ToList();
    }
}