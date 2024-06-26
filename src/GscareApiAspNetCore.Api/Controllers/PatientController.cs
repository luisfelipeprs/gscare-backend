using GscareApiAspNetCore.Api.Attributes;
using GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
using GscareApiAspNetCore.Application.UseCases.PatientUseCases;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GscareApiAspNetCore.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredPatientJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterPatientUseCase useCase,
        [FromBody] RequestPatientJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponsePatientsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllPatients([FromServices] IGetAllPatientsUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Patients.Count != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet("get-patients-by-current-company")]
    [AuthenticatedUser]
    [ProducesResponseType(typeof(ResponsePatientsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetPatientsByCurrentCompany([FromServices] IGetPatientsByCurrentCompanyUseCase useCase)
    {
        var patients = await useCase.Execute();
        return Ok(patients);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePatientJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetPatientByIdUseCase useCases,
        [FromRoute] long id)
    {
        var response = await useCases.Execute(id);

        return Ok(response);
    }

    [HttpGet]
    [Route("current-company")]
    [ProducesResponseType(typeof(ResponsePatientJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetCurrentCompanyByPatientUseCase useCase)
    {
        var company = await useCase.Execute();
        return Ok(company);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeletePatientUseCase useCase,
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
        [FromServices] IUpdatePatientUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestPatientJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpPatch]
    [Route("{patientId}/associate-company/{companyId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AssociatePatientWithCompany(
    [FromServices] IAssociatePatientWithCompanyUseCase useCase,
    [FromRoute] long patientId,
    [FromRoute] long companyId)
    {
        await useCase.Execute(patientId, companyId);
        return NoContent();
    }

    [HttpPatch]
    [Route("{patientId}/disassociate-company")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DisassociatePatientFromCompany(
    [FromServices] IDisassociatePatientFromCompanyUseCase useCase,
    [FromRoute] long patientId)
    {
        await useCase.Execute(patientId);
        return NoContent();
    }
}
