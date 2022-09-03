using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.Provider;

namespace Wms.Core.Application.Queries.EntityQuery.ProviderQueries;

public record ProviderQuery(
    int Id,
    string? Code,
    string? Name,
    string? Document,
    int TypeDoc,
    int Status) : ICommand<List<ProviderResponse>>;