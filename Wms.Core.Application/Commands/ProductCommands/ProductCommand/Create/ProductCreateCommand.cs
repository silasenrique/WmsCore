using Wms.Core.Application.Commands.ProductCommands.ProductCommand.Common;

namespace Wms.Core.Application.Commands.ProductCommands.ProductCommand.Create;

public record ProductCreateCommand : ProductCommonWriteCommand
{
    public ProductCreateCommand(
        string? OwnerCode,
        string? Code,
        string? Description,
        int Status) : base(OwnerCode, Code, Description, Status)
    {
    }
}