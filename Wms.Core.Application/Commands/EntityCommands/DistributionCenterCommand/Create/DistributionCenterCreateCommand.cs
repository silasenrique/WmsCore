using Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Common;

namespace Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Create;

public record DistributionCenterCreateCommand : DistributionCenterCommonWriteCommand
{
    public DistributionCenterCreateCommand(
        string? Code,
        string? Name,
        string? Document) : base(Code, Name, Document)
    {
    }
}
