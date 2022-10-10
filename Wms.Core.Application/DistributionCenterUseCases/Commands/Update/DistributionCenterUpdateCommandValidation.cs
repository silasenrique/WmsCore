using FluentValidation;
using Wms.Core.Application.DistributionCenterUseCases.Commands.Common;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Update;

public class DistributionCenterUpdateCommandValidator : AbstractValidator<DistributionCenterUpdateCommand>
{
    readonly IDistributionCenterRepository _repository;

    public DistributionCenterUpdateCommandValidator(IDistributionCenterRepository repository)
    {
        _repository = repository;
        Validate();
    }

    void Validate()
    {
        Include(new DistributionCenterCommonWriteCommandValidator());

        RuleFor(cd => new { cd.Code, cd.Document })
            .MustAsync(async (code, cancellation) => { var result = await DocumentIsAlreadyAllocated(code.Code, code.Document); return !result; })
            .WithMessage("o documento informado já está alocado a outro centro de distribuição");
    }

    async Task<bool> DocumentIsAlreadyAllocated(string? code, string? document)
    {
        var result = await _repository.DocumentIsAlreadyAllocated(code, document);

        return result is not null;
    }
}