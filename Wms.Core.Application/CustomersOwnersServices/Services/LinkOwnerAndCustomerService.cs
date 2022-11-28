using Wms.Core.Domain.Owner;
using Wms.Core.Domain.Owner.Models;
using Wms.Core.Domain.Owner.Relationship;
using Wms.Core.Persistence.CustomerOwnerPersistence.Repository;

namespace Wms.Core.Application.CustomersOwnersServices.Services;

public class LinkOwnerAndCustomerService : ILinkOwnerAndCustomerService
{
    private readonly ICustomerOwnerRepository _customerOwnerRepository;

    public LinkOwnerAndCustomerService(ICustomerOwnerRepository customerOwnerRepository)
    {
        _customerOwnerRepository = customerOwnerRepository;
    }

    public void LinkOwnerAndCustomer(Owner owner, List<Customer> customers)
    {
        List<CustomerOwner> customersOwners = customers.ConvertAll(n => CustomerOwner.Create(n.Id, owner.Id));

        _customerOwnerRepository.AddRange(customersOwners);
    }
}