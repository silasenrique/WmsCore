using Wms.Core.Application.ShippingUseCases.Commands.Common;

namespace Wms.Core.Application.ShippingUseCases.Commands.Create;

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