using ErrorOr;
using Wms.Core.Domain.Entities.Entity;

namespace Wms.Core.Application.Abstractions.Entity;

public interface IShippingService
{
    Task<ErrorOr<Shipping>> Create(Shipping shipping);
    Task<ErrorOr<Shipping>> Update(Shipping shipping);
    Task<IEnumerable<Shipping>> Get(Shipping shipping);
    Task<Error?> Delete(string code);
}