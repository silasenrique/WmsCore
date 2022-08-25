using Wms.Core.Application.Abstractions.Messaging;
using Wms.Core.Application.Contracts.Entity.Owner;

namespace Wms.Core.Application.Queries.Entity.OwnerQueries;

public record OwnerQuery(
    int Id,
    string? Code,
    string? Name,
    string? Document,
    int TypeDoc,
    int Status) : ICommand<List<OwnerResponse>>;
