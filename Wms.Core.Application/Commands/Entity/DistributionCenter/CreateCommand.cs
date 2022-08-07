using MediatR;

namespace Wms.Core.Application.Commands.DistributionCenterCommand;

public record CreateCommand(
    string Code,
    string Name,
    int Document) : IRequest<DistributionCenterDTO>;