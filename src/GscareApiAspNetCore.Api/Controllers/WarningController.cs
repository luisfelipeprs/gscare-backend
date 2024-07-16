using GscareApiAspNetCore.Api.Attributes;
using GscareApiAspNetCore.Application.UseCases;
using GscareApiAspNetCore.Application.UseCases.WarningUseCases;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Communication.Responses.WarningResponses;
using Microsoft.AspNetCore.Mvc;

namespace GscareApiAspNetCore.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WarningController : ControllerBase
{
    [HttpPost]
    [AuthenticatedUser]
    [ProducesResponseType(typeof(ResponseRegisteredWarningJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterWarningUseCase useCase,
        [FromBody] RequestWarningJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [AuthenticatedUser]
    [ProducesResponseType(typeof(ResponseWarningsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllWarnings([FromServices] IGetAllWarningsUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Warning.Count != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [AuthenticatedUser]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseWarningJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetWarningByIdUseCase useCases,
        [FromRoute] long id)
    {
        var response = await useCases.Execute(id);

        return Ok(response);
    }

    [HttpDelete]
    [AuthenticatedUser]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteWarningUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [AuthenticatedUser]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateWarningUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestWarningJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}
