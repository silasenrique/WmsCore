using System.Linq.Expressions;
using Wms.Core.Domain.Owner;
using Wms.Core.Persistence.Common.Repository;

namespace Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;

public interface IOwnerRepository : IGenericRepository<Owner> { }