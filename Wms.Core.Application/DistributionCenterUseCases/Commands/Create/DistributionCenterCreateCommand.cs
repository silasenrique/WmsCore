using Wms.Core.Application.DistributionCenterUseCases.Commands.Common;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Create;

public record DistributionCenterCreateCommand(
    string Code,
    string? Name,
    string Document) : DistributionCenterCommonWriteCommand(Code, Name, Document);
