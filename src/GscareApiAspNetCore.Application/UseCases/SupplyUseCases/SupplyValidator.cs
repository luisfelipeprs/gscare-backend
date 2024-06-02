using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.SupplyUseCases;
internal class SupplyValidator : AbstractValidator<RequestSupplyJson>
{
    public SupplyValidator()
    {
        RuleFor(user => user.Nome).NotEmpty().WithMessage("É obrigatório informar o Nome");
        RuleFor(user => user.Comentario).NotEmpty().WithMessage("É obrigatório informar o Comentario");
    }
}
