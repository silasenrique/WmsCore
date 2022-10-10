namespace Wms.Core.Application.DistributionCenterUseCases.Contract;

public record DistributionCenterResponse(
    int Id,
    string Code,
    string? Name,
    string Document,
    string CreationDate,
    string LastChangeDate);