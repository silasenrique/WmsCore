using MediatR;

namespace Wms.Core.Application.DTOs;

public record DistributionCenterDTO : IRequest<List<DistributionCenterDTO>>
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
    public string? CreationDate { get; set; }
    public string? LastChangeDate { get; set; }
}