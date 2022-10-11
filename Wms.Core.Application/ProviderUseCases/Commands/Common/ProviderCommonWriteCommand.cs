using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProviderUseCases.Contracts;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProviderUseCases.Commands.Common;

public record ProviderCommonWriteCommand(
    string Code,
    string Name,
    string Document,
    TypeEntity TypeDoc,
    GlobalStatus Status) : ICommand<ErrorOr<ProviderResponse>>;