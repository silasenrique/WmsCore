using ErrorOr;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Services;

public class DistributionCenterServices
{
    public DistributionCenterServices(IDistributionCenterRepository repository)
    {
        _repository = repository;
    }
    
    private readonly IDistributionCenterRepository _repository;

    private readonly Error _codeIsAlreadyBeingUsed = Error.Conflict();
    private readonly Error _documentIsAlreadyBeingUsed = Error.Conflict();
    private readonly Error _idNotFound = Error.Conflict();

    public async Task<Error?> ValidCreateDistributionCenter(DistributionCenter distributionCenter)
    {
        if (await CodeAlreadyBeingUsed(distributionCenter.Code)) return _codeIsAlreadyBeingUsed;
        if (await DocumentIsAlreadyBeingUsed(distributionCenter.Document)) return _documentIsAlreadyBeingUsed;

        return null;
    }
    
    private async Task<bool> CodeAlreadyBeingUsed(string code)
    {
        return await _repository.GetByCode(code) is not null;
    }

    private async Task<bool> DocumentIsAlreadyBeingUsed(string document)
    {
        return await _repository.GetByDocument(document) is not null;
    }
}