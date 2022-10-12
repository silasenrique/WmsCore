using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProviderUseCases.Contracts;

public record ProviderResponse(
    int Id,
    string Code,
    string Document,
    string Name,
    TypeEntity TypeDoc,
    GlobalStatus GlobalStatus,
    string CreationDate,
    string LastChangeDate);
