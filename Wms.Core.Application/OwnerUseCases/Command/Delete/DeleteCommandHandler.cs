using System.Linq.Expressions;
using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Domain.Owner;
using Wms.Core.Persistence.Common.UnitOfWork;
using Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;

namespace Wms.Core.Application.OwnerUseCases.Command.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, Error?>
{
    private IOwnerRepository _repository;
    private IUnitOfWork _unitOfWork;

    public DeleteCommandHandler(IOwnerRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Error?> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<Owner, bool>> expression;
        Owner? owner;

        switch (request)
        {
            case request.Code?:
                expression = e => e.Code == request.Code;
            case request.Document ? is not null :
                expression = e => e.Code == request.Code;
        }



        await _unitOfWork.SaveChangesAsync(cancellationToken);


        return null;
    }
}