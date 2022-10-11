using Wms.Core.Application.ProviderUseCases.Commands.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProviderUseCases.Commands.Update;

public record ProviderUpdateCommand : ProviderCommonWriteCommand
{
    public ProviderUpdateCommand(
        int id,
        string Code,
        string Name,
        string Document,
        TypeEntity TypeDoc,
        GlobalStatus Status) : base(Code, Name, Document, TypeDoc, Status)
    {
        Id = id;
    }

    public int Id { get; set; }


}