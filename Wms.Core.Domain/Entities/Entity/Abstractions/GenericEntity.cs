using Wms.Core.Domain.Enums;

namespace Wms.Core.Domain.Entities.Entity.Abstractions;

public abstract class GenericEntity
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
    public TypeEntity TypeDoc { get; set; }
    public GlobalStatus Status { get; set; }
}