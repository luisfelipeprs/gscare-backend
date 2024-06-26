using GscareApiAspNetCore.Api.Attributes;
using GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GscareApiAspNetCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredEmployeeJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterEmployeeUseCase useCase,
        [FromBody] RequestEmployeeJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    //[AuthenticatedUser]
    [ProducesResponseType(typeof(ResponseEmployeesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllEmployees([FromServices] IGetAllEmployeesUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Employees.Count != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet("get-employees-by-current-company")]
    [AuthenticatedUser]
    [ProducesResponseType(typeof(ResponseEmployeesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetEmployeesByCurrentCompany([FromServices] IGetEmployeesByCurrentCompanyUseCase useCase)
    {
        var employees = await useCase.Execute();
        return Ok(employees);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseEmployeeJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetEmployeeByIdUseCase useCases,
        [FromRoute] long id)
    {
        var response = await useCases.Execute(id);
        return Ok(response);
    }

    [HttpGet]
    [Route("current-company")]
    [AuthenticatedUser]
    [ProducesResponseType(typeof(ResponseEmployeeJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetCurrentCompanyByEmployeeUseCase useCase)
    {
        var company = await useCase.Execute();
        return Ok(company);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteEmployeeUseCase useCase,
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
        [FromServices] IUpdateEmployeeUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestEmployeeJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
    
    [HttpPatch]
    [Route("{employeeId}/associate-company/{companyId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AssociateEmployeeWithCompany(
    [FromServices] IAssociateEmployeeWithCompanyUseCase useCase,
    [FromRoute] long employeeId,
    [FromRoute] long companyId)
    {
        await useCase.Execute(employeeId, companyId);
        return NoContent();
    }

    [HttpPatch]
    [Route("{employeeId}/disassociate-company")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DisassociateEmployeeFromCompany(
    [FromServices] IDisassociateEmployeeFromCompanyUseCase useCase,
    [FromRoute] long employeeId)
    {
        await useCase.Execute(employeeId);
        return NoContent();
    }
}
