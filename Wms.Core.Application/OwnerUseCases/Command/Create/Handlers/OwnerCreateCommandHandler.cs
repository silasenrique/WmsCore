using ErrorOr;
using Wms.Core.Domain.Owner;
using Wms.Core.Persistence.Common.UnitOfWork;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Command.Create.Commands;
using Wms.Core.Persistence.OwnerPersistenceConfiguration.Repository;
using Wms.Core.Domain.Owner.Models;
using Wms.Core.Application.CustomerServices.Services.CreateOwnerCustomerServices;
using Wms.Core.Application.CustomersOwnersServices.Services;
using System.Linq.Expressions;
using Wms.Core.Application.OwnerUseCases.Services;

namespace Wms.Core.Application.OwnerUseCases.Command.Create.Handlers;

public class OwnerCreateCommandHandler : ICommandHandler<OwnerCreateCommand, ErrorOr<OwnerResponse>>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILinkOwnerAndCustomerService _customerOwnerService;
    private readonly ICreateOwnerService _ownerService;
    private readonly ICustomerServiceCreateOrReferACustomerToAnOwner _customerService;

    public OwnerCreateCommandHandler(IOwnerRepository ownerRepository,
                                    IUnitOfWork unitOfWork,
                                    ICustomerServiceCreateOrReferACustomerToAnOwner customerService,
                                    ILinkOwnerAndCustomerService customerOwnerService,
                                    ICreateOwnerService ownerService)
    {
        _ownerRepository = ownerRepository;
        _unitOfWork = unitOfWork;
        _customerService = customerService;
        _customerOwnerService = customerOwnerService;
        _ownerService = ownerService;
    }

    public async Task<ErrorOr<OwnerResponse>> Handle(OwnerCreateCommand command, CancellationToken cancellationToken)
    {
        Owner owner = Owner.Create(
            command.Code,
            command.Name,
            command.Document
        );

        Error? canOwnerDataBeUsed = _ownerService.CanOwnerDataBeUsed(owner);
        if (canOwnerDataBeUsed is not null) return (Error)canOwnerDataBeUsed;

        _ownerRepository.Create(owner);

        ErrorOr<List<Customer>> newCustomersOrErrors = _customerService.CreateOrReferACustomerToAnOwner(command.Customers);
        if (newCustomersOrErrors.IsError) return newCustomersOrErrors.Errors;

        _customerOwnerService.LinkOwnerAndCustomer(owner, newCustomersOrErrors.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        Expression<Func<Owner, bool>> expression = e => e.Id == owner.Id;

        return OwnerResponse.Create(_ownerRepository.Get(expression)!.FirstOrDefault()!);
    }
}