using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repositories;

public class GenericRepository<TEntity> where TEntity : class
{
    internal readonly DbContext _context;
    internal readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task Delete(TEntity entityToDelete)
    {
        _dbSet.Remove(entityToDelete);
        await SaveChanges();
    }

    public async Task Insert(TEntity entityToInsert)
    {
        await _dbSet.AddAsync(entityToInsert);
        await SaveChanges();
    }

    public async Task Update(TEntity entityToUpdate)
    {
        _dbSet.Update(entityToUpdate);
        await SaveChanges();
    }

    public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
    {
        return await _dbSet.Where(filter).AsNoTracking().ToListAsync();
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}