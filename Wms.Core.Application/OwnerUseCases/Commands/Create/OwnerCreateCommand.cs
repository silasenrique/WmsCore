using Wms.Core.Application.OwnerUseCases.Commands.Common;

namespace Wms.Core.Application.OwnerUseCases.Commands.Create;

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
