using FluentValidation;
using Wms.Core.Application.DistributionCenterUseCases.Commands.Common;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.DistributionCenterUseCases.Commands.Create;

public class DistributionCenterCreateCommandValidator : AbstractValidator<DistributionCenterCreateCommand>
{
    readonly IDistributionCenterRepository _repository;

    public DistributionCenterCreateCommandValidator(IDistributionCenterRepository repository)
    {
        _repository = repository;
        Validate();
    }

    void Validate()
    {
        Include(new DistributionCenterCommonWriteCommandValidator());

        RuleFor(d => d.Code)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (code, cancellation) => { bool result = await CodeAlreadyExists(code); return !result; })
            .WithMessage("valor já foi informado anteriormente");

        RuleFor(d => d.Document)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (doc, cancellation) => { bool result = await DocumentAlreadyExists(doc); return !result; })
            .WithMessage("{PropertyValue} já foi informado anteriormente para outro centro de distribuição!");
    }

    async Task<bool> DocumentAlreadyExists(string document)
    {
        return await _repository.GetByDocument(document) is not null;
    }

    async Task<bool> CodeAlreadyExists(string code)
    {
        return await _repository.GetByCode(code) is not null;
    }
}