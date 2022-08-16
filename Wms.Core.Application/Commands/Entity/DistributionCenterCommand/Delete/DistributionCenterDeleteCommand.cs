using ErrorOr;
using MediatR;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Delete;

public record DistributionCenterDeleteCommand : IRequest<Error?>
{
    public int Id { get; set; }
}