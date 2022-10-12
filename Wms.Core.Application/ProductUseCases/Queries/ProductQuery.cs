using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProductUseCases.Contract;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProductUseCases.Queries;

public record ProductQuery(
    int? Id,
    string? Code,
    string? Description,
    GlobalStatus? Status,
    string? OwnerCode
) : ICommand<List<ProductResponse>>;