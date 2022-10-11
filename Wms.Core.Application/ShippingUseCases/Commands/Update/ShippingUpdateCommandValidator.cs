using FluentValidation;
using Wms.Core.Application.ShippingUseCases.Commands.Common;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;

namespace Wms.Core.Application.ShippingUseCases.Commands.Update;

public class ShippingUpdateCommandValidator : AbstractValidator<ShippingUpdateCommand>
{
    readonly IShippingRepository _repository;

    public ShippingUpdateCommandValidator(IShippingRepository repository)
    {
        _repository = repository;
        Validate();
    }

    void Validate()
    {
        Include(new ShippingCommonWriteCommandValidator());

        RuleFor(cd => new { cd.Code, cd.Document })
            .MustAsync(async (code, cancellation) => { var result = await DocumentIsAlreadyAllocated(code.Code, code.Document); return !result; })
            .WithMessage("o documento informado já está alocado a outra transportadora");
    }

    async Task<bool> DocumentIsAlreadyAllocated(string? code, string? document)
    {
        var result = await _repository.DocumentIsAlreadyAllocated(code, document);

        return result is not null;
    }
}