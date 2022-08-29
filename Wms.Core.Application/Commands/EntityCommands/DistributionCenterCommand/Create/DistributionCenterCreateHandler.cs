using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;
using MapsterMapper;
using Wms.Core.Domain.Entities.Entity;
using ErrorOr;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Create;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Create;

public class DistributionCenterCreateHandler : ICommandHandler<DistributionCenterCreateCommand, ErrorOr<DistributionCenterResponse>>
{
    readonly IDistributionCenterRepository _repository;
    readonly IMapper _mapper;

    public DistributionCenterCreateHandler(IDistributionCenterRepository distributionCenterRepository, IMapper mapper)
    {
        _repository = distributionCenterRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterCreateCommand command, CancellationToken cancellationToken)
    {
        await _repository.Insert(_mapper.Map<DistributionCenter>(command));

        return _mapper.Map<DistributionCenterResponse>(await _repository.GetByCode(command.Code));
    }
}