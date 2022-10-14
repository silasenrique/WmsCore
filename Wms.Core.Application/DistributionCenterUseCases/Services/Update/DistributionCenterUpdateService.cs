using ErrorOr;
using Wms.Core.Application.DistributionCenterUseCases.Errors;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Services.Update;

public class DistributionCenterUpdateService : IDistributionCenterUpdateService
{
    private readonly IDistributionCenterRepository _repository;

    public DistributionCenterUpdateService(IDistributionCenterRepository repository)
    {
        _repository = repository;
    }

    public async Task<Error?> ValidateUpdateDistributionCenter(DistributionCenter distributionCenter)
    {
        DistributionCenter? oldDistributionCenter = await _repository.GetById(distributionCenter.Id);
        
        if (oldDistributionCenter is null) return DistributionCenterValidationErrors.IdNotFound;
        if (await IsTheNewDocumentAlreadyBeingUsed(oldDistributionCenter.Document, distributionCenter.Document)) return DistributionCenterValidationErrors.DocumentIsAlreadyBeingUsed;
        if (await IsTheNewCodeAlreadyBeingUsed(oldDistributionCenter.Document, distributionCenter.Document)) return DistributionCenterValidationErrors.CodeIsAlreadyBeingUsed;
        
        return null;
    }
    
    private async Task<bool> IsTheNewDocumentAlreadyBeingUsed(string oldDocument, string newDocument)
    {
        if (oldDocument == newDocument) return false;
        
        return await _repository.GetByDocument(newDocument) is not null;
    }
    
    private async Task<bool> IsTheNewCodeAlreadyBeingUsed(string oldCode, string newCode)
    {
        if (oldCode == newCode) return false;
        
        return await _repository.GetByCode(newCode) is not null;
    }
}