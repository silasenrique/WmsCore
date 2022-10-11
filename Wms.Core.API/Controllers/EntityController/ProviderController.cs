using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.ProviderUseCases.Commands.Create;
using Wms.Core.Application.ProviderUseCases.Commands.Delete;
using Wms.Core.Application.ProviderUseCases.Commands.Update;
using Wms.Core.Application.ProviderUseCases.Queries;

namespace Wms.Core.API.Controllers.EntityController;

[Route("api/provider")]
public class ProviderController : MainController
{
    readonly ISender _sender;

    public ProviderController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] ProviderQuery query)
    {
        return Ok(await _sender.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProviderCreateCommand command)
    {
        var created = await _sender.Send(command);

        return created.Match(
            created => Ok(created),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<ActionResult> Update(ProviderUpdateCommand command)
    {
        var updated = await _sender.Send(command);

        return updated.Match(
            updated => Ok(updated),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(ProviderDeleteCommand command)
    {
        var deletedError = await _sender.Send(command);

        if (deletedError is not null)
        {
            return Problem((Error)deletedError);
        }

        return NoContent();
    }
}