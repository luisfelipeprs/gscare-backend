using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Exception;
using GscareApiAspNetCore.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GscareApiAspNetCore.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is GscareException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnkowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException)
        {
            var ex = (ErrorOnValidationException)context.Exception;

            var errorResponse = new ResponseErrorJson(ex.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseErrorJson(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }

    private void ThrowUnkowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
