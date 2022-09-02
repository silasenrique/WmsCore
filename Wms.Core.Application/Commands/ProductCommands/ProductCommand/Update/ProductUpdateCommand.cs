using Wms.Core.Application.Commands.ProductCommands.ProductCommand.Common;

namespace Wms.Core.Application.Commands.ProductCommands.ProductCommand.Update;

public record ProductUpdateCommand : ProductCommonWriteCommand
{
    public int Id { get; set; }

    public ProductUpdateCommand(int id, string OwnerCode, string Code, string Description, int Status) : base(OwnerCode, Code, Description, Status)
    {
        Id = id;
    }
}
