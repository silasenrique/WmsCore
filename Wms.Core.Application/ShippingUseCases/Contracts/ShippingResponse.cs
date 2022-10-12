using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ShippingUseCases.Contracts;

public record ShippingResponse(
    int Id,
    string Code,
    string Document,
    string Name,
    TypeEntity TypeDoc,
    GlobalStatus GlobalStatus,
    string CreationDate,
    string LastChangeDate
);