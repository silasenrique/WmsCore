using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using Wms.Core.Application.DistributionCenterUseCases.Services.Create;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Create;

public class DistributionCenterCreateHandler : ICommandHandler<DistributionCenterCreateCommand, ErrorOr<DistributionCenterResponse>>
{
    private readonly IDistributionCenterRepository _repository;
    private readonly IDistributionCenterCreateService _service;
    
    public DistributionCenterCreateHandler(IDistributionCenterRepository distributionCenterRepository, IDistributionCenterCreateService service)
    {
        _repository = distributionCenterRepository;
        _service = service;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterCreateCommand command, CancellationToken cancellationToken)
    {
        DistributionCenter? distributionCenter = new DistributionCenter(
            command.Code,
            command.Name,
            command.Document);
        
        Error? isValid = await _service.ValidCreateDistributionCenter(distributionCenter);
        if (isValid is not null) return (Error)isValid;
        
        await _repository.Insert(distributionCenter);

        distributionCenter = await _repository.GetByCode(command.Code);

        return new DistributionCenterResponse(distributionCenter.Id, 
            distributionCenter.Code,
            distributionCenter.Name, 
            distributionCenter.Document,
            distributionCenter.CreationDate,
            distributionCenter.LastChangeDate);
    }
}