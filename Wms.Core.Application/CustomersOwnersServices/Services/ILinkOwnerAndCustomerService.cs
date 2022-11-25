using Wms.Core.Domain.Owner;
using Wms.Core.Domain.Owner.Models;

namespace Wms.Core.Application.CustomersOwnersServices.Services;

public interface ILinkOwnerAndCustomerService
{
    void LinkOwnerAndCustomer(Owner owner, List<Customer> customers);
}