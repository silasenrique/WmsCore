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
}