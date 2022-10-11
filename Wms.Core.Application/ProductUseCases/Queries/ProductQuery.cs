using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProductUseCases.Contract;

namespace Wms.Core.Application.ProductUseCases.Queries;

public record ProductQuery(
    int Id,
    string? Code,
    string? Description,
    int Status,
    string? OwnerCode
) : ICommand<List<ProductResponse>>;