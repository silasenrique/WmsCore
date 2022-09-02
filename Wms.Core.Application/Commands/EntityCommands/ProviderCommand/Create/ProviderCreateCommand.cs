using Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Common;

namespace Wms.Core.Application.Commands.EntityCommands.ProviderCommand.Create;

public record ProviderCreateCommand : ProviderCommonWriteCommand
{
    public ProviderCreateCommand(
        string Code,
        string Name,
        string Document,
        int TypeDoc,
        int Status) : base(Code, Name, Document, TypeDoc, Status)
    {
    }
}