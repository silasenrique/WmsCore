using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.OwnerUseCases.Commands.Create;
using Wms.Core.Application.OwnerUseCases.Commands.Delete;
using Wms.Core.Application.OwnerUseCases.Commands.Update;
using Wms.Core.Application.OwnerUseCases.Queries;

namespace Wms.Core.API.Controllers.EntityController;

[Route("api/owner")]
public class OwnerController : MainController
{
    readonly ISender _sender;

    public OwnerController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult> Create(OwnerCreateCommand command)
    {
        var created = await _sender.Send(command);

        return created.Match(
            created => Ok(created),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<ActionResult> Update(OwnerUpdateCommand command)
    {
        var updated = await _sender.Send(command);

        return updated.Match(
            updated => Ok(updated),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] OwnerDeleteCommand command)
    {
        var deletedErr = await _sender.Send(command);

        if (deletedErr != null)
        {
            return BadRequest(deletedErr);
        }

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] OwnerQuery query)
    {
        return Ok(await _sender.Send(query));
    }
}