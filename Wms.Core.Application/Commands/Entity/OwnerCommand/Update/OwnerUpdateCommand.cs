using ErrorOr;
using Wms.Core.Application.Abstractions.Messaging;
using Wms.Core.Application.Contracts.Entity.Owner;

namespace Wms.Core.Application.Commands.Entity.OwnerCommand.Update;

public record OwnerUpdateCommand(
    int Id,
    string Code,
    string Name,
    string Document,
    int TypeDoc,
    int Status) : ICommand<ErrorOr<OwnerResponse>>;