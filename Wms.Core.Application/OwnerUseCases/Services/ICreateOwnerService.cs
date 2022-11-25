using ErrorOr;
using Wms.Core.Domain.Owner;

namespace Wms.Core.Application.OwnerUseCases.Services;

public interface ICreateOwnerService
{
    Error? CanOwnerDataBeUsed(Owner newOwner);
}