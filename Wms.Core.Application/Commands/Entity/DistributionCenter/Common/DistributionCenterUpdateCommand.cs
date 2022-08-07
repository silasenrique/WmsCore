using ErrorOr;
using MediatR;
using Wms.Core.Application.DTOs;

namespace Wms.Core.Application.Commands.Entity.DistributionCenter.Common;

public record DistributionCenterUpdateCommand(
    int Id,
    string Code,
    string Name,
    string Document) : IRequest<ErrorOr<DistributionCenterDTO>>;