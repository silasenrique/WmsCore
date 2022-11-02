namespace Wms.Core.Application.DistributionCenterUseCases.Contract;

public record DistributionCenterResponse(
    int Id,
    string Code,
    string Name,
    string Document,
    DateTime CreationDate,
    DateTime LastChangeDate);