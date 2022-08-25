using Wms.Core.Domain.Entities.Entity.Abstractions;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Entity;

public class Provider : GenericEntity
{
    public Provider(string? code) : base(code)
    {
    }

    public Provider(string? code, string? name, string? document, TypeEntity typeDoc, GlobalStatus status) : base(code, name, document, typeDoc, status)
    {
    }

    public Provider(int id, string? code, string? name, string? document, TypeEntity typeDoc, GlobalStatus status) : base(id, code, name, document, typeDoc, status)
    {
    }
}