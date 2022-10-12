using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Create;

public class DistributionCenterCreateHandler : ICommandHandler<DistributionCenterCreateCommand, ErrorOr<DistributionCenterResponse>>
{
    readonly IDistributionCenterRepository _repository;
    
    public DistributionCenterCreateHandler(IDistributionCenterRepository distributionCenterRepository)
    {
        _repository = distributionCenterRepository;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterCreateCommand command, CancellationToken cancellationToken)
    {
        DistributionCenter distributionCenter = new DistributionCenter(
            command.Code,
            command.Name,
            command.Document);
        
        await _repository.Insert(distributionCenter);

        distributionCenter = await _repository.GetByCode(command.Code);

        return new DistributionCenterResponse(distributionCenter.Id, 
            distributionCenter.Code,
            distributionCenter.Name, 
            distributionCenter.Document,
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(distributionCenter.CreationDate).ToLocalTime().ToString(), 
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(distributionCenter.LastChangeDate).ToLocalTime().ToString());
    }
}