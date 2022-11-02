using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.OwnerUseCases.Contracts;

public record OwnerResponse(
    int Id,
    string Code,
    string Document,
    string Name,
    TypeEntity TypeDoc,
    GlobalStatus GlobalStatus,
    DateTime CreationDate,
    DateTime LastChangeDate
);