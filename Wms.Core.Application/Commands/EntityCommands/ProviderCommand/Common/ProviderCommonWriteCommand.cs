using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.EntityContract.Provider;

namespace Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Common;

public record ProviderCommonWriteCommand(
    string Code,
    string Name,
    string Document,
    int TypeDoc,
    int Status) : ICommand<ErrorOr<ProviderResponse>>;