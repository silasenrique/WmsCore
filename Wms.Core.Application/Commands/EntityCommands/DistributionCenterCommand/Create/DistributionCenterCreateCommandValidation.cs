using FluentValidation;
using Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Common;
using Wms.Core.Application.Commands.EntityCommands.DistributionCenterCommand.Create;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.Entity.DistributionCenterCommand;

public class DistributionCenterCreateCommandValidation : AbstractValidator<DistributionCenterCreateCommand>
{
    readonly IDistributionCenterRepository _repository;

    public DistributionCenterCreateCommandValidation(IDistributionCenterRepository repository)
    {
        _repository = repository;
        Validate();
    }

    void Validate()
    {
        Include(new DistributionCenterWriteCommandValidation());

        RuleFor(d => d.Code)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (code, cancellation) => { bool result = await CodeAlreadyExists(code); return !result; })
            .WithMessage("valor já foi informado anteriormente");

        RuleFor(d => d.Document)
            .Cascade(CascadeMode.Stop)
            .MustAsync(async (doc, cancellation) => { bool result = await DocumentAlreadyExists(doc); return !result; })
            .WithMessage("valor já foi informado anteriormente!");
    }

    async Task<bool> DocumentAlreadyExists(string document)
    {
        var exist = await _repository.GetByDocument(document);

        return exist is not null;
    }

    async Task<bool> CodeAlreadyExists(string code)
    {
        var exist = await _repository.GetByCode(code);

        return exist is not null;
    }
}