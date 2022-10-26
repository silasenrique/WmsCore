using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.DistributionCenterUseCases.Contract;
using Wms.Core.Application.DistributionCenterUseCases.Errors;
using Wms.Core.Application.DistributionCenterUseCases.Services.Update;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Update.UpdateDocument;

public class DistributionCenterUpdateNameHandler : ICommandHandler<DistributionCenterUpdateDocumentCommand, ErrorOr<DistributionCenterResponse>>
{
    private readonly IDistributionCenterRepository _repository;
    private readonly IDistributionCenterUpdateService _service;

    public DistributionCenterUpdateNameHandler(IDistributionCenterRepository repository, IDistributionCenterUpdateService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<ErrorOr<DistributionCenterResponse>> Handle(DistributionCenterUpdateDocumentCommand command, CancellationToken cancellationToken)
    {
        DistributionCenter? cd = await _repository.GetById(command.Id);
        if (cd is null) return DistributionCenterValidationErrors.IdNotFound;
        
        cd.ChangeDocument(command.Document);

        Error? isValid = await _service.ValidateUpdateDistributionCenter(cd);
        if (isValid is not null) return (Error)isValid;

        await _repository.Update(cd);

        return new DistributionCenterResponse(
            cd.Id,
            cd.Code,
            cd.Name,
            cd.Document,
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(cd.CreationDate).ToLocalTime().ToString(), 
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(cd.LastChangeDate).ToLocalTime().ToString());
    }
}