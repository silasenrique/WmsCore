using Wms.Core.Application.ProductUseCases.Commands.Common;

namespace Wms.Core.Application.ProductUseCases.Commands.Create;

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