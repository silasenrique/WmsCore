using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ShippingUseCases.Contracts;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ShippingUseCases.Queries;

public record ShippingQuery(
    int? Id,
    string? Code,
    string? Name,
    string? Document,
    TypeEntity? TypeDoc,
    GlobalStatus? Status) : ICommand<List<ShippingResponse>>;