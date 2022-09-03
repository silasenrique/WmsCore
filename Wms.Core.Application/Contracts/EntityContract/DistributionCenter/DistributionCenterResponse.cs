namespace Wms.Core.Application.Contracts.EntityContract.DistributionCenter;

public record DistributionCenterResponse
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
    public string? CreationDate { get; set; }
    public string? LastChangeDate { get; set; }
}