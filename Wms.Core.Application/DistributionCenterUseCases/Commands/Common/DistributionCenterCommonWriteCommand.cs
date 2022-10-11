using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Common;

public record DistributionCenterCommonWriteCommand(
    string Code,
    string? Name,
    string Document) : ICommand<ErrorOr<DistributionCenterResponse>>;