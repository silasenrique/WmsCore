using Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Common;

namespace Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Create;

public record DistributionCenterCreateCommand : DistributionCenterWriteCommonCommand
{
    public DistributionCenterCreateCommand(
        string? Code,
        string? Name,
        string? Document) : base(Code, Name, Document)
    {
    }
}
