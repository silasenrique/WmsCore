using Wms.Core.Application.DistributionCenterUseCases.Commands.Common;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Create;

public record DistributionCenterCreateCommand : DistributionCenterCommonWriteCommand
{
    public DistributionCenterCreateCommand(
        string? Code,
        string? Name,
        string? Document) : base(Code, Name, Document)
    {
    }
}
