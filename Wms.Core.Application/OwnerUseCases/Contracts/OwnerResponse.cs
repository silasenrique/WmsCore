using Wms.Core.Application.CustomerServices.Contracts;
using Wms.Core.Domain.Owner;

namespace Wms.Core.Application.OwnerUseCases.Contracts;

public record OwnerResponse(
    Guid Id,
    string Code,
    string Name,
    string Document,
    List<CustomerResponse> Customers,
    List<ShippingCompanyResponse> Carriers,
    List<SupplierResponse> Suppliers
)
{
    public static OwnerResponse Create(Owner owner)
    {
        List<CustomerResponse> customers = new();
        List<ShippingCompanyResponse> carriers = new();
        List<SupplierResponse> suppliers = new();

        owner.Customers.ForEach(c => customers.Add(
            new CustomerResponse(
                    c.Customer.Id,
                    c.Customer.Code,
                    c.Customer.Name,
                    c.Customer.Document)
        ));

        // owner.Suppliers.ForEach(s => suppliers.Add(new SupplierResponse(s.Id, s.Code, s.Name, s.Document)));
        // owner.Carriers.ForEach(s => carriers.Add(new ShippingCompanyResponse(s.Id, s.Code, s.Name, s.Document)));

        return new OwnerResponse(
            owner.Id,
            owner.Code,
            owner.Name,
            owner.Document,
            customers,
            carriers,
            suppliers);
    }

    public static IEnumerable<OwnerResponse> Create(IEnumerable<Owner> owners)
    {
        return owners.Select(o => Create(o));
    }
};