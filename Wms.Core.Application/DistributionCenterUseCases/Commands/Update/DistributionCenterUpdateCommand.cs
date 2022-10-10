using Wms.Core.Application.DistributionCenterUseCases.Commands.Common;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Update;

public record DistributionCenterUpdateCommand : DistributionCenterCommonWriteCommand
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
