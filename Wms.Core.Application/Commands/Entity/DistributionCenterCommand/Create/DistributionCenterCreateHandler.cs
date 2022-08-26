using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;
using MapsterMapper;
using Wms.Core.Domain.Entities.Entity;
using ErrorOr;
using Wms.Core.Application.Contracts.Entity.DistributionCenter;
using Wms.Core.Application.ApplicationErrors;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand.Create;

public class DistributionCenterCreateHandler : ICommandHandler<DistributionCenterCreateCommand, ErrorOr<DistributionCenterResponse>>
{
    readonly IDistributionCenterRepository _distributionCenterRepository;
    readonly IMapper _mapper;

    public DistributionCenterCreateHandler(IDistributionCenterRepository distributionCenterRepository, IMapper mapper)
    {
        _distributionCenterRepository = distributionCenterRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterCreateCommand command, CancellationToken cancellationToken)
    {
        var newDistributionCenter = _mapper.Map<DistributionCenter>(command);

        if (await _distributionCenterRepository.GetByCode(command.Code) is not null)
        {
            return DistributionCenterErrors.CodeHasBeenEnteredBefore;
        }

        await _distributionCenterRepository.Insert(newDistributionCenter);

        return _mapper.Map<DistributionCenterResponse>(await _distributionCenterRepository.GetByCode(command.Code));
    }
}