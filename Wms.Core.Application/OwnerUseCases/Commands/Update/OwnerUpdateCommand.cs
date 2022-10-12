using Wms.Core.Application.OwnerUseCases.Commands.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.OwnerUseCases.Commands.Update;

public record OwnerUpdateCommand(
    int Id,
    string Code,
    string Name,
    string Document,
    TypeEntity TypeDoc,
    GlobalStatus Status) : OwnerWriteCommonWriteCommand(Code, Name, Document, TypeDoc, Status);