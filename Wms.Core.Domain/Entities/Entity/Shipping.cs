using Wms.Core.Domain.Entities.Entity.Abstractions;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Entity;

public class Shipping : GenericEntity
{
    public Shipping(string? code) : base(code)
    {
    }

    public Shipping(string? code, string? name, string? document, TypeEntity typeDoc, GlobalStatus status) : base(code, name, document, typeDoc, status)
    {
    }

    public Shipping(int id, string? code, string? name, string? document, TypeEntity typeDoc, GlobalStatus status) : base(id, code, name, document, typeDoc, status)
    {
    }
}