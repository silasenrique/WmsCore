using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.OwnerUseCases.Contracts;

namespace Wms.Core.Application.OwnerUseCases.Commands.Common;

public record OwnerWriteCommonWriteCommand
        (string Code,
        string Name,
        string Document,
        int TypeDoc,
        int Status) : ICommand<ErrorOr<OwnerResponse>>;