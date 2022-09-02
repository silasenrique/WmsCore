using Wms.Core.Application.Commands.EntityCommands.ShippingCommand.Common;

namespace Wms.Core.Application.Commands.EntityCommands.ShippingCommand.Create;

public record ShippingCreateCommand : ShippingCommonWriteCommand
{
    public ShippingCreateCommand(
        string Code,
        string Name,
        string Document,
        int TypeDoc,
        int Status) : base(Code, Name, Document, TypeDoc, Status)
    {
    }
}