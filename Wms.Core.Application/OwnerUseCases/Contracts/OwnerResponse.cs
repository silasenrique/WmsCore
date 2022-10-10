namespace Wms.Core.Application.OwnerUseCases.Contracts;

public record OwnerResponse(
    int Id,
    string Code,
    string Document,
    int TypeDoc,
    int GlobalStatus,
    string CreationDate,
    string LastChangeDate
);
