using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.Commands.Entity.ShippingCommand.Create;
using Wms.Core.Application.Commands.Entity.ShippingCommand.Delete;
using Wms.Core.Application.Commands.Entity.ShippingCommand.Update;
using Wms.Core.Application.Queries.Entity.ShippingQueries;

namespace Wms.Core.API.Controllers.Entities;

[Route("api/shipping")]
public class ShippingController : MainController
{
    readonly ISender _sender;

    public ShippingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] ShippingQuery query)
    {
        return Ok(await _sender.Send(query));
    }

    [HttpPost]
    public async Task<ActionResult> Create(ShippingCreateCommand command)
    {
        var created = await _sender.Send(command);

        return created.Match(
            created => Ok(created),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<ActionResult> Update(ShippingUpdateCommand command)
    {
        var updated = await _sender.Send(command);

        return updated.Match(
            updated => Ok(updated),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(ShippingDeleteCommand command)
    {
        var deletedError = await _sender.Send(command);

        if (deletedError is not null)
        {
            return Problem((Error)deletedError);
        }

        return NoContent();
    }

}