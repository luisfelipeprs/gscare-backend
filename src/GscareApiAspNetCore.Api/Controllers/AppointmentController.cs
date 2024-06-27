using GscareApiAspNetCore.Application.UseCases.AppointmentUseCases;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.AppointmentResponses;
using GscareApiAspNetCore.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GscareApiAspNetCore.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredAppointmentJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterAppointmentUseCase useCase,
        [FromBody] RequestAppointmentJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAppointmentsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllAppointments([FromServices] IGetAllAppointmentsUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Appointments.Count != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseAppointmentJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetAppointmentByIdUseCase useCases,
        [FromRoute] long id)
    {
        var response = await useCases.Execute(id);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteAppointmentUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateAppointmentUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestAppointmentJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}
