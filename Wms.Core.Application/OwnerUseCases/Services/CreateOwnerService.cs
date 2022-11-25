using System.Linq.Expressions;
using ErrorOr;
using Wms.Core.Domain.Owner;
using Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;

namespace Wms.Core.Application.OwnerUseCases.Services;

public class CreateOwnerService : ICreateOwnerService
{
    private readonly IOwnerRepository _repository;
    private Expression<Func<Owner, bool>> Expression { get; set; } = default!;

    public CreateOwnerService(IOwnerRepository repository)
    {
        _repository = repository;
    }

    public Error? CanOwnerDataBeUsed(Owner newOwner)
    {
        if (TheCodeIsAlreadyBeingUsed(newOwner.Code))
        {
            return Error.Conflict(
                "TheCodeIsAlreadyBeingUsed",
                "O código do informado já existe, é necessário informar outro código"
            );
        }

        if (TheDocumentIsAlreadyBeingUsed(newOwner.Document))
        {
            return Error.Conflict(
                "TheDocumentIsAlreadyBeingUsed",
                "O documento informado já existe, é necessário informar outro código"
            );
        }

        return null;
    }

    private bool TheCodeIsAlreadyBeingUsed(string code)
    {
        Expression = e => e.Code == code;
        return _repository.Get(Expression).Any();
    }

    private bool TheDocumentIsAlreadyBeingUsed(string document)
    {
        Expression = e => e.Document == document;
        return _repository.Get(Expression).Any();
    }
}