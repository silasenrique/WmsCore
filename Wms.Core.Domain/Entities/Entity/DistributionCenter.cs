namespace Wms.Core.Domain.Entities.Entity;

public record DistributionCenter
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public int Document { get; set; }
}