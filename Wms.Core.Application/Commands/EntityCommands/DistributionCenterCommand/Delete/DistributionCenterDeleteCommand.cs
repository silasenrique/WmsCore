using ErrorOr;
using MediatR;

namespace Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Delete;

public record DistributionCenterDeleteCommand(string Code) : IRequest<Error?>;