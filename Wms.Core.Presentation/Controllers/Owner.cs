using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.OwnerUseCases.Command.Create.Commands;
using Wms.Core.Application.OwnerUseCases.Command.Delete;
using Wms.Core.Application.OwnerUseCases.Contracts;
using Wms.Core.Application.OwnerUseCases.Queries;

namespace Wms.Core.Presentation.Controllers;

[Route("api/owner")]
public class OwnerController : MainController
{
    private readonly ISender _sender;

    public OwnerController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult> Create(OwnerCreateCommand command)
    {
        ErrorOr<OwnerResponse> response = await _sender.Send(command);

        return response.Match(
            response => Ok(response),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] OwnerQuery query)
    {
        return Ok(await _sender.Send(query));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeleteCommand delete)
    {
        Error? deleteOrError = await _sender.Send(delete);

        if (deleteOrError is not null)
        {
            return Problem((Error)deleteOrError);
        }

        return NoContent();
    }
}