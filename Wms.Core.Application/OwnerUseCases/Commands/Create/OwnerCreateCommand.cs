using Wms.Core.Application.OwnerUseCases.Commands.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.OwnerUseCases.Commands.Create;

public record OwnerCreateCommand : OwnerWriteCommonWriteCommand
{
    public OwnerCreateCommand(
        string Code,
        string Name,
        string Document,
        TypeEntity TypeDoc,
        GlobalStatus Status) : base(Code, Name, Document, TypeDoc, Status)
    {
    }
}