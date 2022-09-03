using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.Owner;

namespace Wms.Core.Application.Queries.EntityQuery.OwnerQueries;

public record OwnerQuery(
    int Id,
    string? Code,
    string? Name,
    string? Document,
    int TypeDoc,
    int Status) : ICommand<List<OwnerResponse>>;
