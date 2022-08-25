namespace Wms.Core.Application.Contracts.Entity.Owner;

public record OwnerResponse(
    int Id,
    string Code,
    string Document,
    int TypeDoc,
    int GlobalStatus,
    string CreationDate,
    string LastChangeDate
);