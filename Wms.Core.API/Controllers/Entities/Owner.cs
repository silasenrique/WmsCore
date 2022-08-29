using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Create;
using Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Delete;
using Wms.Core.Application.Commands.EntityCommands.OwnerCommand.Update;
using Wms.Core.Application.Queries.Entity.OwnerQueries;

namespace Wms.Core.API.Controllers.Entities;

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