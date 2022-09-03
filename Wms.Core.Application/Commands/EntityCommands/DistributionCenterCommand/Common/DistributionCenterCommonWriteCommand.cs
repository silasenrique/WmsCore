using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.DistributionCenter;

namespace Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Common;

public record DistributionCenterCommonWriteCommand(
    string? Code,
    string? Name,
    string? Document) : ICommand<ErrorOr<DistributionCenterResponse>>;