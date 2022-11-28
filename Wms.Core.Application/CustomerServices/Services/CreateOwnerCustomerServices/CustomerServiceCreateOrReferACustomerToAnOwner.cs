using System.Linq.Expressions;
using ErrorOr;
using Wms.Core.Application.CustomerServices.Commands.Create;
using Wms.Core.Domain.Owner.Models;
using Wms.Core.Persistence.CustomerPersistence.Repository;

namespace Wms.Core.Application.CustomerServices.Services.CreateOwnerCustomerServices;

public class CustomerServiceCreateOrReferACustomerToAnOwner : ICustomerServiceCreateOrReferACustomerToAnOwner
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerServiceCreateOrReferACustomerToAnOwner(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public ErrorOr<List<Customer>> CreateOrReferACustomerToAnOwner(CreateOrReferACustomerToAnOwner customers)
    {
        if (!IsCreatingOrReferencing(customers)) return Error.Conflict();

        List<Customer> ownerCustomers = new();

        if (customers.NewCustomers is not null)
            ownerCustomers.AddRange(CreateNewCustomers(customers.NewCustomers));

        if (customers.ExistingCustomers is not null)
            ownerCustomers.AddRange(GetExistingCustomers(customers.ExistingCustomers)!);

        return ownerCustomers;
    }

    private bool IsCreatingOrReferencing(CreateOrReferACustomerToAnOwner customers)
    {
        return customers.ExistingCustomers is not null || customers.NewCustomers is not null;
    }

    private List<Customer> CreateNewCustomers(List<CustomerCreateCommand> createCustomers)
    {
        List<Customer> newCustomers = createCustomers
            .ConvertAll(c => Customer.Create(
                    c.Code,
                    c.Name,
                    c.Document));

        _customerRepository.AddRange(newCustomers);

        return newCustomers;
    }

    private List<Customer>? GetExistingCustomers(List<Guid> customersId)
    {
        Expression<Func<Customer, bool>> expression = e => customersId.Contains(e.Id);

        return _customerRepository.Get(expression)?.ToList();
    }
}