using FluentValidation;
using Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Common;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Update;

public class OwnerUpdateCommandValidator : AbstractValidator<OwnerUpdateCommand>
{
    readonly IOwnerRepository _repository;

    public OwnerUpdateCommandValidator(IOwnerRepository repository)
    {
        _repository = repository;
        Validate();
    }

    void Validate()
    {
        Include(new OwnerWriteCommonWriteCommandValidator());

        RuleFor(cd => new { cd.Code, cd.Document })
            .MustAsync(async (code, cancellation) => { var result = await DocumentIsAlreadyAllocated(code.Code, code.Document); return !result; })
            .WithMessage("o documento informado já está alocado a outro proprietário");
    }

    async Task<bool> DocumentIsAlreadyAllocated(string? code, string? document)
    {
        var result = await _repository.DocumentIsAlreadyAllocated(code, document);

        return result is not null;
    }
}