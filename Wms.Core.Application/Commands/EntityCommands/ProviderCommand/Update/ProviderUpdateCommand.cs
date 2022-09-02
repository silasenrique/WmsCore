using Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Common;

namespace Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Update;

public record ProviderUpdateCommand : ProviderCommonWriteCommand
{
    public ProviderUpdateCommand(
        int id,
        string Code,
        string Name,
        string Document,
        int TypeDoc,
        int Status) : base(Code, Name, Document, TypeDoc, Status)
    {
        Id = id;
    }

    public int Id { get; set; }


}