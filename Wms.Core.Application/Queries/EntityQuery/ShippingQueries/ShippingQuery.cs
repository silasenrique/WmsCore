using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.Shipping;

namespace Wms.Core.Application.Queries.EntityQuery.ShippingQueries;

public record ShippingQuery(
    int Id,
    string? Code,
    string? Name,
    string? Document,
    int TypeDoc,
    int Status) : ICommand<List<ShippingResponse>>;