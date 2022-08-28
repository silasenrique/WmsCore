using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.Contracts.Product.Product;

namespace Wms.Core.Application.Commands.ProductCommands.ProductCommand.Create;

public record ProductCreateCommand(
    int Id,
    string? Code,
    string? Description,
    int Status,
    string? OwnerCode) : ICommand<ErrorOr<ProductResponse>>;