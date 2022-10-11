using Wms.Core.Application.DistributionCenterUseCases.Commands.Common;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Update;

public record DistributionCenterUpdateCommand(
    int Id,
    string Code,
    string? Name,
    string Document) : DistributionCenterCommonWriteCommand(Code, Name, Document);