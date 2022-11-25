namespace Wms.Core.Application.OwnerUseCases.Contracts;

public record ShippingCompanyResponse(
    Guid Id,
    string Code,
    string Name,
    string Document
);