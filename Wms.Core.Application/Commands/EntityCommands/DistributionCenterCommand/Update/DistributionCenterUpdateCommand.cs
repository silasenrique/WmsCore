using Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Common;

namespace Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Update;

public record DistributionCenterUpdateCommand : DistributionCenterWriteCommonCommand
{
    public int Id { get; set; }

    public DistributionCenterUpdateCommand(
        int id,
        string? code,
        string? name,
        string? document) : base(code, name, document)
    {
        Id = id;
    }
}
