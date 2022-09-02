using Wms.Core.Application.Commands.EntityCommands.ShippingCommand.Common;

namespace Wms.Core.Application.Commands.EntityCommands.ShippingCommand.Update;

public record ShippingUpdateCommand : ShippingCommonWriteCommand
{
    public int Id { get; set; }

    public ShippingUpdateCommand(
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