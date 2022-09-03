namespace Wms.Core.Application.Contracts.EntityContract.Provider;

public record ProviderResponse(
    int Id,
    string Code,
    string Document,
    int TypeDoc,
    int GlobalStatus,
    string CreationDate,
    string LastChangeDate);
