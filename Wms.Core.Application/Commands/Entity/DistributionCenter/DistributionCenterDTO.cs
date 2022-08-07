namespace Wms.Core.Application.Commands.DistributionCenterCommand;

public record DistributionCenterDTO
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public int Document { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastChangeDate { get; set; }
}