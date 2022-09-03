using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Wms.Core.API.Controllers.UnitizerController;

[Route("api/unitizer")]
public class UnitizerTypeController : MainController
{
    readonly ISender _sender;

    public UnitizerTypeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] UnitizerTypeQuery query)
    {
        var unitizers = await _sender.Send(query);

        return Ok(unitizers);
    }

    [HttpPost]
    public async Task<ActionResult> Create(UnitizerTypeCreateCommand command)
    {
        var created = await _sender.Send(command);

        return created.Match(
            created => Ok(created),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<ActionResult> Update(UnitizerTypeUpdateCommand command)
    {
        var updated = await _sender.Send(command);

        return updated.Match(
            updated => Ok(updated),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(UnitizerTypeDeleteCommand command)
    {
        var deletedError = await _sender.Send(command);

        if (deletedError is not null) return Problem((Error)deletedError);

        return NoContent();
    }
}