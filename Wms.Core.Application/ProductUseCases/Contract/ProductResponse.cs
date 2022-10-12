using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProductUseCases.Contract;

public record ProductResponse(
    int Id,
    string Code,
    string Description,
    GlobalStatus Status,
    string OwnerCode,
    string CreationDate,
    string LastChangeDate
);