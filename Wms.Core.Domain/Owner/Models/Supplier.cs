using Wms.Core.Domain.Common.Models;

namespace Wms.Core.Domain.Owner.Models;

public class Supplier : Entity
{
    public Supplier(Guid id, string code, string name, string document) : base(id)
    {
        Code = code;
        Name = name;
        Document = document;
    }

    public static Supplier Create(string code, string name, string document)
    {
        return new Supplier(Guid.NewGuid(), code, name, document);
    }

    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
}