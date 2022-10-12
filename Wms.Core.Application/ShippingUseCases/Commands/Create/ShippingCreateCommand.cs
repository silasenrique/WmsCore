using Wms.Core.Application.ShippingUseCases.Commands.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ShippingUseCases.Commands.Create;

public record ShippingCreateCommand(
    string Code,
    string Name,
    string Document,
    TypeEntity TypeDoc,
    GlobalStatus Status) : ShippingCommonWriteCommand(Code, Name, Document, TypeDoc, Status);