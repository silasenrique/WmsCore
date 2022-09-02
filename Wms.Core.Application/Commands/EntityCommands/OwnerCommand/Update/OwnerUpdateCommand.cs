using Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Common;

namespace Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Update;

public record OwnerUpdateCommand : OwnerWriteCommonWriteCommand
{
    public int Id { get; set; }

    public OwnerUpdateCommand(
        int id,
        string Code,
        string Name,
        string Document,
        int TypeDoc,
        int Status) : base(Code, Name, Document, TypeDoc, Status)
    {
        Id = id;
    }
}