using System.Linq.Expressions;
using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Domain.Owner;
using Wms.Core.Persistence.Common.UnitOfWork;
using Wms.Core.Persistence.CustomerOwnerPersistence.Repository;
using Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;

namespace Wms.Core.Application.OwnerUseCases.Command.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, Error?>
{
    private IOwnerRepository _repository;
    private IUnitOfWork _unitOfWork;
    private ICustomerOwnerRepository _customerOwner;

    public DeleteCommandHandler(IOwnerRepository repository, IUnitOfWork unitOfWork, ICustomerOwnerRepository customerOwner)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _customerOwner = customerOwner;
    }

    public async Task<Error?> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<Owner, bool>> expression = e =>
           (e.Code == request.Code || request.Code == null) &&
           (e.Document == request.Document || request.Document == null) &&
           (e.Id == request.Id || request.Id == null);

        Owner? owner = _repository.Get(expression)?.FirstOrDefault();
        if (owner is null) return Error.NotFound();

        _customerOwner.GetOwnerCustomer(owner.Id);

        await _unitOfWork.SaveChangesAsync(cancellationToken);


        return null;
    }
}