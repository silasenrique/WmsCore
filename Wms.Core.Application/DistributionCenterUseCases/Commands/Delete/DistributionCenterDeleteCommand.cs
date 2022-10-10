using ErrorOr;
using MediatR;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Delete;

public record DistributionCenterDeleteCommand(string Code) : IRequest<Error?>;