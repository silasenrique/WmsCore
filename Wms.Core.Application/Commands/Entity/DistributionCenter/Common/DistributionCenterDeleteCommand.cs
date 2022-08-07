using ErrorOr;
using MediatR;

namespace Wms.Core.Application.Commands.Entity.DistributionCenter.Common;

public record DistributionCenterDeleteCommand : IRequest<Error?>
{
    public int Id { get; set; }
}