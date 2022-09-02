using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Product.Product;

namespace Wms.Core.Application.Commands.ProductCommands.ProductCommand.Common;

public record ProductCommonWriteCommand(
    string OwnerCode,
    string Code,
    string Description,
    int Status) : ICommand<ErrorOr<ProductResponse>>;