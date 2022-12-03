using Wms.Core.Domain.Common.Models;
using Wms.Core.Domain.Owner.Relationship;

namespace Wms.Core.Domain.Owner.Models;

public class Customer : Entity
{
    private Customer(Guid id, string code, string name, string document) : base(id)
    {
        Code = code;
        Name = name;
        Document = document;
    }

    private Customer(Guid id) : base(id) { }

    public static Customer Create(Guid id, string code, string name, string document)
    {
        return new Customer(id, code, name, document);
    }

    public static Customer Create(string code, string name, string document)
    {
        return new Customer(Guid.NewGuid(), code, name, document);
    }

    public static Customer Create(Guid id)
    {
        return new Customer(id);
    }

    public string Code { get; }
    public string Name { get; }
    public string Document { get; }
    public List<CustomerOwner> Owners { get; } = new();
}