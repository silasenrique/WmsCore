using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Wms.Core.API.Controllers;

[ApiController]
public class MainController : ControllerBase
{
    protected ActionResult Problem(List<Error> errors)
    {
        //  HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        var firstError = errors[0];

        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = firstError.Code,
            Detail = firstError.Description
        };

        errors.ForEach(e => problemDetails.Extensions.Add(e.Code, e.Description));

        return new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };
    }
}