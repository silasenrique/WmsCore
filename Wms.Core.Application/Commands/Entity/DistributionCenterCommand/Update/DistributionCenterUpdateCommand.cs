using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Update;

public record DistributionCenterUpdateCommand(
    int Id,
    string Code,
    string Name,
    string Document) : ICommand<ErrorOr<DistributionCenterResponse>>;