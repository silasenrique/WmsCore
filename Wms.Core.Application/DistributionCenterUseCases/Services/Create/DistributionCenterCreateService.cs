using ErrorOr;
using Wms.Core.Application.DistributionCenterUseCases.Errors;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Services.Create;

public class DistributionCenterCreateService : IDistributionCenterCreateService
{
    public DistributionCenterCreateService(IDistributionCenterRepository repository)
    {
        _repository = repository;
    }
    
    private readonly IDistributionCenterRepository _repository;
    
    public async Task<Error?> ValidCreateDistributionCenter(DistributionCenter distributionCenter)
    {
        if (await CodeAlreadyBeingUsed(distributionCenter.Code)) return DistributionCenterValidationErrors.CodeIsAlreadyBeingUsed;
        if (await DocumentIsAlreadyBeingUsed(distributionCenter.Document)) return DistributionCenterValidationErrors.DocumentIsAlreadyBeingUsed;

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