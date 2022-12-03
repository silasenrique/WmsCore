using System.Linq.Expressions;
using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Domain.Owner;
using Wms.Core.Domain.Owner.Models;
using Wms.Core.Domain.Owner.Relationship;
using Wms.Core.Persistence.Common.UnitOfWork;
using Wms.Core.Persistence.CustomerOwnerPersistence.Repository;
using Wms.Core.Persistence.CustomerPersistence.Repository;
using Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;

namespace Wms.Core.Application.OwnerUseCases.Command.Delete;

public class DeleteCommandHandler : ICommandHandler<DeleteCommand, Error?>
{
    private IOwnerRepository _repository;
    private IUnitOfWork _unitOfWork;
    private ICustomerOwnerRepository _customerOwner;
    private ICustomerRepository _customer;

    public DeleteCommandHandler(IOwnerRepository repository, IUnitOfWork unitOfWork, ICustomerOwnerRepository customerOwner, ICustomerRepository customer)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _customerOwner = customerOwner;
        _customer = customer;
    }

    public async Task<Error?> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<Owner, bool>> expression = e =>
           (e.Code == request.Code || request.Code == null) &&
           (e.Document == request.Document || request.Document == null) &&
           (e.Id == request.Id || request.Id == null);

        Owner? owner = _repository.GetOnlyOwner(expression);
        if (owner is null) return Error.NotFound();

        // List<CustomerOwner>? ownerCustomers = _customerOwner.GetOwnerCustomers(owner.Id);
        // if (!request.DeleteDependencies && ownerCustomers is not null) return Error.Conflict();

        List<CustomerOwner> customersDeleted = _customerOwner.DeleteCustomersNotLinkedToAnotherOwner(owner.Id);
        if (customersDeleted.Any())
        {
            _customer.DeleteRange(customersDeleted!.ConvertAll(c => Customer.Create(c.CustomerId)));
        }

        _repository.Delete(owner);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return null;
    }
}