using Wms.Core.Application.OwnerUseCases.Commands.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.OwnerUseCases.Commands.Update;

public record OwnerUpdateCommand : OwnerWriteCommonWriteCommand
{
    public OwnerUpdateCommand(
        int id,
        string Code,
        string Name,
        string Document,
        TypeEntity TypeDoc,
        GlobalStatus Status) : base(Code, Name, Document, TypeDoc, Status)
    {
        Id = id;
    }

    public int Id { get; set; }
}