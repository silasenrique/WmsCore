using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Wms.Core.Domain.Common.Models;
using Wms.Core.Domain.Entities.Entity.Abstractions;
using Wms.Core.Infrastructure.Context;

namespace Wms.Core.Infrastructure.Repositories;

public class GenericRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context)
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
        TrackInsert();
        TrackUpdate();
        await _context.SaveChangesAsync();
    }

    private void TrackInsert()
    {
        IEnumerable<object> insertedRecords = _context.ChangeTracker.Entries()
            .Where(c => c.State == EntityState.Added)
            .Select(c => c.Entity);

        foreach (object insertedRecord in insertedRecords)
        {
            if (insertedRecord is not Audit audit) continue;
            audit.CreateRecord();
        }
    }
    
    private void TrackUpdate()
    {
        IEnumerable<object> updatedRecords = _context.ChangeTracker.Entries()
            .Where(c => c.State == EntityState.Modified)
            .Select(c => c.Entity);

        foreach (object updateRecord in updatedRecords)
        {
            if (updateRecord is not Audit audit) continue;
            audit.UpdateRecord();
        }
    }
}