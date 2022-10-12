using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;

namespace Wms.Core.Application.OwnerUseCases.Queries;

public record OwnerQuery(
    int? Id,
    string? Code,
    string? Name,
    string? Document,
    int? TypeDoc,
    int? Status) : ICommand<List<OwnerResponse>>;