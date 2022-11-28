using Wms.Core.Domain.Owner.Models;

namespace Wms.Core.Domain.Owner.Relationship;

public class CustomerOwner
{
    public Guid CustomerId { get; private set; }
    public Guid OwnerId { get; private set; }
    public Owner Owner { get; private set; }
    public Customer Customer { get; private set; }

    private CustomerOwner(Owner owner, Customer customer)
    {
        Owner = owner;
        Customer = customer;
        CustomerId = customer.Id;
        OwnerId = owner.Id;
    }

    private CustomerOwner(Guid customerId, Guid ownerId)
    {
        CustomerId = customerId;
        OwnerId = ownerId;
    }

    public static CustomerOwner Create(Owner owner, Customer customer)
    {
        return new CustomerOwner(owner, customer);
    }

    public static CustomerOwner Create(Guid customerId, Guid ownerId)
    {
        return new CustomerOwner(customerId, ownerId);
    }
}