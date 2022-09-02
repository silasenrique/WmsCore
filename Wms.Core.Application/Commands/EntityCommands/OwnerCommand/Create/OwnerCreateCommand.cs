using Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Common;

namespace Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Create;

public record OwnerCreateCommand : OwnerWriteCommonWriteCommand
{
    public OwnerCreateCommand(
        string Code,
        string Name,
        string Document,
        int TypeDoc,
        int Status) : base(Code, Name, Document, TypeDoc, Status)
    {
    }
}
