namespace Wms.Core.Application.OwnerUseCases.Contracts;

public record SupplierResponse(
    Guid Id,
    string Code,
    string Name,
    string Document
);