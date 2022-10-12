using Wms.Core.Application.OwnerUseCases.Commands.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.OwnerUseCases.Commands.Create;

public record OwnerCreateCommand(
    string Code,
    string Name,
    string Document,
    TypeEntity TypeDoc,
    GlobalStatus Status) : OwnerWriteCommonWriteCommand(Code, Name, Document, TypeDoc, Status);