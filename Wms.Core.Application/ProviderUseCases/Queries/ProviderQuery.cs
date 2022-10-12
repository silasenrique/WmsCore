using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProviderUseCases.Contracts;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProviderUseCases.Queries;

public record ProviderQuery(
    int? Id,
    string? Code,
    string? Name,
    string? Document,
    TypeEntity? TypeDoc,
    GlobalStatus? Status) : ICommand<List<ProviderResponse>>;