using ErrorOr;
using MapsterMapper;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Create;

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