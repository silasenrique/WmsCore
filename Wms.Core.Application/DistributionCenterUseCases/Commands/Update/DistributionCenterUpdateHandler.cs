using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using Wms.Core.Application.DistributionCenterUseCases.Services.Update;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Update;

public class DistributionCenterUpdateHandler : ICommandHandler<DistributionCenterUpdateCommand, ErrorOr<DistributionCenterResponse>>
{
    private readonly IDistributionCenterRepository _repository;
    private readonly IDistributionCenterUpdateService _service;

    public DistributionCenterUpdateHandler(IDistributionCenterRepository distributionCenterRepository, IDistributionCenterUpdateService service)
    {
        _repository = distributionCenterRepository;
        _service = service;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterUpdateCommand command, CancellationToken cancellationToken)
    {
        DistributionCenter? updated = new DistributionCenter(
            command.Id,
            command.Code,
            command.Name,
            command.Document);

        Error? isValid = await _service.ValidateUpdateDistributionCenter(updated);
        if (isValid is not null) return (Error)isValid;

        await _repository.Update(updated);

        updated = await _repository.GetByCode(command.Code);

        return new DistributionCenterResponse(
            updated.Id, 
            updated.Code,
            updated.Name, 
            updated.Document,
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(updated.CreationDate).ToLocalTime().ToString(), 
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(updated.LastChangeDate).ToLocalTime().ToString());
    }
}