using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases.StockUseCases;
internal class StockValidator : AbstractValidator<RequestStockJson>
{
    public StockValidator()
    {
        RuleFor(stock => stock.Nome_Produto).NotEmpty().WithMessage("stock name is required");
        RuleFor(stock => stock.Categoria_Produto).NotEmpty().WithMessage("category product is required");
        // Add other validation rules as needed
    }
}