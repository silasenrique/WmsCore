using Wms.Core.Application.ProductUseCases.Commands.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProductUseCases.Commands.Create;

public record ProductCreateCommand(
    string OwnerCode,
    string Code,
    string Description,
    GlobalStatus Status) : ProductCommonWriteCommand(OwnerCode, Code, Description, Status);