using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;

namespace Wms.Core.Application.ShippingUseCases.Commands.Delete;

public record ShippingDeleteCommand(string Code) : ICommand<Error?>;