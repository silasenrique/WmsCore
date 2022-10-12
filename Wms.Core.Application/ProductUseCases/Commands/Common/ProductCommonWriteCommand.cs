using ErrorOr;
using Wms.Core.Application.Common.Interfaces.Messaging;
using Wms.Core.Application.ProductUseCases.Contract;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProductUseCases.Commands.Common;

public record ProductCommonWriteCommand(
    string OwnerCode,
    string Code,
    string Description,
    GlobalStatus Status) : ICommand<ErrorOr<ProductResponse>>;