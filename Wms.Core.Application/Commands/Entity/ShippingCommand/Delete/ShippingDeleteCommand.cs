using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.Commands.Entity.ShippingCommand.Delete;

public record ShippingDeleteCommand(string Code) : ICommand<Error?>;