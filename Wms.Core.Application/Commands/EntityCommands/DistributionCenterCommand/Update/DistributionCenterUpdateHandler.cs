using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.DistributionCenter;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Update;

public class DistributionCenterUpdateHandler : ICommandHandler<DistributionCenterUpdateCommand, ErrorOr<DistributionCenterResponse>>
{
    readonly IDistributionCenterRepository _repository;
    readonly IMapper _mapper;

    public DistributionCenterUpdateHandler(IDistributionCenterRepository distributionCenterRepository, IMapper mapper)
    {
        _repository = distributionCenterRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterUpdateCommand command, CancellationToken cancellationToken)
    {
        var updated = _mapper.Map<DistributionCenter>(command);

        await _repository.Update(updated);

        return _mapper.Map<DistributionCenterResponse>(await _repository.GetByCode(command.Code));
    }
}