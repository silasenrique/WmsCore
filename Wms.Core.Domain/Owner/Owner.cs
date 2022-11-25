using Wms.Core.Domain.Common.Models;
using Wms.Core.Domain.Owner.Relationship;

namespace Wms.Core.Domain.Owner;

public class Owner : Entity
{
    public string Code { get; }
    public string Name { get; }
    public string Document { get; }
    public List<CustomerOwner> Customers { get; } = new();

    private Owner(Guid id, string code, string name, string document) : base(id)
    {
        Code = code;
        Name = name;
        Document = document;
    }

    private Owner(Guid id) : base(id) { }

    public static Owner Create(Guid id)
    {
        return new Owner(id);
    }

    public static Owner Create(string code, string name, string document)
    {
        return new Owner(Guid.NewGuid(), code, name, document);
    }

    //public void CopyCustomerOfAnotherOwner(Owner ownerBase, List<Guid> customersToCopy)
    //{
    //    if (!customersToCopy.Any()) return;
    //    if (!ownerBase.Customers.Any()) return;
    //
    //    // TODO: não deixar copiar algo que já existe na lista de destino
    //
    //    ownerBase.Customers.AsEnumerable()
    //        .Where(c => customersToCopy.Contains(c.Id))
    //        .ToList()
    //        .ForEach(b => Customers.Add(
    //            Customer.Create(b.Code, b.Name, b.Document))
    //        );
    //}

    //public void CreateCustomer(string code, string name, string document)
    //{
    //    Customers.Add(Customer.Create(code, name, document));
    //}
    //
    //public void AddExistingCustomer(Customer customer)
    //{
    //    Customers.Add(Customer.Create(customer.Id, customer.Code, customer.Name, customer.Document));
    //}
}