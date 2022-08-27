namespace Wms.Core.Application.Contracts.Entity.Shipping;

public record ShippingResponse(
    int Id,
    string Code,
    string Document,
    int TypeDoc,
    int GlobalStatus,
    string CreationDate,
    string LastChangeDate
);