namespace Wms.Core.Application.CustomerServices.Commands.Create;

public record CreateOrReferACustomerToAnOwner(
    List<CustomerCreateCommand>? NewCustomers,
    List<Guid>? ExistingCustomers
);