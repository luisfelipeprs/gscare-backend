using GscareApiAspNetCore.Application.UseCases;
using GscareApiAspNetCore.Application.UseCases.StockUseCases;
using GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Communication.Responses.StockResponses;
using GscareApiAspNetCore.Communication.Responses.SupplyResponses;
using Microsoft.AspNetCore.Mvc;

namespace GscareApiAspNetCore.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredStockJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterStockUseCase useCase,
        [FromBody] RequestStockJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseStocksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllStocks([FromServices] IGetAllStocksUseCase useCase)
    {
        var response = await useCase.Execute();

        if (response.Stocks.Count != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseStockJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetStockByIdUseCase useCases,
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
        [FromServices] IDeleteStockUseCase useCase,
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
        [FromServices] IUpdateStockUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestStockJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }
}
