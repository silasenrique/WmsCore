using Wms.Core.Application.ProviderUseCases.Commands.Common;
using Wms.Core.Domain.Enums;

namespace Wms.Core.Application.ProviderUseCases.Commands.Create;

public record ProviderCreateCommand(
    string Code,
    string Name,
    string Document,
    TypeEntity TypeDoc,
    GlobalStatus Status) : ProviderCommonWriteCommand(Code, Name, Document, TypeDoc, Status);