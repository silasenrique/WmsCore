namespace Wms.Core.Application.Contracts.Entity.DistributionCenter;

public record DistributionCenterResponse
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
    public long CreationDate { get; set; }
    public long LastChangeDate { get; set; }
}