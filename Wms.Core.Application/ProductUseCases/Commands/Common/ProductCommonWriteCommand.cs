using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProductUseCases.Contract;

namespace Wms.Core.Application.ProductUseCases.Commands.Common;

public record ProductCommonWriteCommand(
    string OwnerCode,
    string Code,
    string Description,
    int Status) : ICommand<ErrorOr<ProductResponse>>;