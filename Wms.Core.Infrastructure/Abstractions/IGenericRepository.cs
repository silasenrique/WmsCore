using System.Linq.Expressions;

namespace Wms.Core.Infrastructure.Abstractions;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task Delete(TEntity entityToDelete);
    Task Insert(TEntity entityToInsert);
    Task Update(TEntity entityToUpdate);
    Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter);
}