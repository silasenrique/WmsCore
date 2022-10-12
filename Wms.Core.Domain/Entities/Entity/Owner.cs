using Wms.Core.Domain.Entities.Entity.Abstractions;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Entity;

public class Owner : GenericEntity
{
    public Owner(string code) : base(code)
    {
    }

    public Owner(string code, string name, string document, TypeEntity typeDoc, GlobalStatus status) : base(code, name, document, typeDoc, status)
    {
    }

    public Owner(int id, string code, string name, string document, TypeEntity typeDoc, GlobalStatus status) : base(id, code, name, document, typeDoc, status)
    {
    }
}