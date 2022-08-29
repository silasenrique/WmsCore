using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wms.Core.Application.Commands.ProductCommands.ProductCommand.Create;
using Wms.Core.Application.Commands.ProductCommands.ProductCommand.Delete;
using Wms.Core.Application.Commands.ProductCommands.ProductCommand.Update;
using Wms.Core.Application.Queries.ProductQueries;

namespace Wms.Core.API.Controllers.ProductController;

[Route("api/product")]
public class ProductController : MainController
{
    readonly ISender _sender;

    public ProductController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] ProductQuery query)
    {
        return Ok(await _sender.Send(query));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(ProductDeleteCommand command)
    {
        var deletedError = await _sender.Send(command);

        if (deletedError is not null)
        {
            return Problem((Error)deletedError);
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProductCreateCommand command)
    {
        var created = await _sender.Send(command);

        return created.Match(
            created => Ok(created),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<ActionResult> Update(ProductUpdateCommand command)
    {
        var updated = await _sender.Send(command);

        return updated.Match(
            updated => Ok(updated),
            errors => Problem(errors)
        );
    }
}