using ErrorOr;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.Abstractions.Entity;

public interface IOwnerService
{
    Task<ErrorOr<Owner>> Create(Owner owner);
    Task Delete(string code);
    Task<IEnumerable<Owner>> Get(Owner owner);
    Task<ErrorOr<Owner>> Update(Owner owner);
}