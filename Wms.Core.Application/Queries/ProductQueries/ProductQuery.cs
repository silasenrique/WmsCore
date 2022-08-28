using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Product.Product;

namespace Wms.Core.Application.Queries.ProductQueries;

public record ProductQuery(
    int Id,
    string? Code,
    string? Description,
    int Status,
    string? OwnerCode
) : ICommand<List<ProductResponse>>;