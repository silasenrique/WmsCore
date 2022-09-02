using FluentValidation;
using Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Common;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Create;

public class OwnerCreateCommandValidator : AbstractValidator<OwnerCreateCommand>
{
    readonly IOwnerRepository _repository;

    public OwnerCreateCommandValidator(IOwnerRepository repository)
    {
        _repository = repository;
        Validate();
    }

    void Validate()
    {
        Include(new OwnerWriteCommonWriteCommandValidator());

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
        return await _repository.GetByDocument(document) is not null;
    }

    async Task<bool> CodeAlreadyExists(string code)
    {
        return await _repository.GetByCode(code) is not null;
    }
}