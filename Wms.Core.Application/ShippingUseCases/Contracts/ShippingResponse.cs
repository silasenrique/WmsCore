namespace Wms.Core.Application.ShippingUseCases.Contracts;

public record ShippingResponse(
    int Id,
    string Code,
    string Document,
    int TypeDoc,
    int GlobalStatus,
    string CreationDate,
    string LastChangeDate
);