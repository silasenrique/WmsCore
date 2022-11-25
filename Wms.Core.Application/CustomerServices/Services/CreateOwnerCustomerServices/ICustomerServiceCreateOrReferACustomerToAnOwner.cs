using ErrorOr;
using Wms.Core.Application.CustomerServices.Commands.Create;
using Wms.Core.Domain.Owner.Models;

namespace Wms.Core.Application.CustomerServices.Services.CreateOwnerCustomerServices;

public interface ICustomerServiceCreateOrReferACustomerToAnOwner
{
    ErrorOr<List<Customer>> CreateOrReferACustomerToAnOwner(CreateOrReferACustomerToAnOwner customers);
}