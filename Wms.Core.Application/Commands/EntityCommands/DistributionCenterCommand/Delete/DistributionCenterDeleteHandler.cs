using ErrorOr;
using MapsterMapper;
using MediatR;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Delete;

public class DistributionCenterDeleteHandler : IRequestHandler<DistributionCenterDeleteCommand, Error?>
{
    readonly IDistributionCenterRepository _repository;
    readonly IMapper _mapper;


    public DistributionCenterDeleteHandler(IDistributionCenterRepository repository, IMediator mediator, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Error?> Handle(DistributionCenterDeleteCommand command, CancellationToken cancellationToken)
    {
        var cd = _mapper.Map<DistributionCenter>(command);

        await _repository.Delete(cd);

        return null;
    }
}