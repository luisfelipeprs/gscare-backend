using GscareApiAspNetCore.Application.UseCases;
using GscareApiAspNetCore.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GscareApiAspNetCore.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterEmployeeJson request)
    {
        var useCase = new RegisterEmployeeUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
