using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ShippingUseCases.Contracts;

namespace Wms.Core.Application.ShippingUseCases.Queries;

public record ShippingQuery(
    int Id,
    string? Code,
    string? Name,
    string? Document,
    int TypeDoc,
    int Status) : ICommand<List<ShippingResponse>>;