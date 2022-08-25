using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Entity.Abstractions;

public abstract class GenericEntity
{
    protected GenericEntity(string? code)
    {
        Code = code;
    }

    protected GenericEntity(string? code, string? name, string? document, TypeEntity typeDoc, GlobalStatus status) : this(code)
    {
        Name = name;
        Document = document;
        TypeDoc = typeDoc;
        Status = status;
        CreationDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        LastChangeDate = CreationDate;
    }

    protected GenericEntity(int id, string? code, string? name, string? document, TypeEntity typeDoc, GlobalStatus status)
    {
        Id = id;
        Code = code;
        Name = name;
        Document = document;
        TypeDoc = typeDoc;
        Status = status;
        LastChangeDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }

    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
    public TypeEntity TypeDoc { get; set; }
    public GlobalStatus Status { get; set; }
    public long CreationDate { get; set; }
    public long LastChangeDate { get; set; }
}