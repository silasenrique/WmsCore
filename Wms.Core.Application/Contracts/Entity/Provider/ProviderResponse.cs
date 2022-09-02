namespace Wms.Core.Application.Contracts.Entity.Provider;

public record ProviderResponse(
    int Id,
    string Code,
    string Document,
    int TypeDoc,
    int GlobalStatus,
    string CreationDate,
    string LastChangeDate);
