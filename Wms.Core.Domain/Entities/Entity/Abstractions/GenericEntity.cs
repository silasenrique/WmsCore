using Wms.Core.Domain.Common.Models;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Entity.Abstractions;

public abstract class GenericEntity : Audit
{
    protected GenericEntity(string code)
    {
        Code = code;
    }

    protected GenericEntity(string code, string name, string document, TypeEntity typeDoc, GlobalStatus status) : this(code)
    {
        Name = name;
        Document = document;
        TypeDoc = typeDoc;
        Status = status;
    }

    protected GenericEntity(int id, string code, string name, string document, TypeEntity typeDoc, GlobalStatus status)
    {
        Id = id;
        Code = code;
        Name = name;
        Document = document;
        TypeDoc = typeDoc;
        Status = status;
    }

    public int Id { get; private set; }
    public string Code { get; private  set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public TypeEntity TypeDoc { get; private set; }
    public GlobalStatus Status { get; private set; }
}