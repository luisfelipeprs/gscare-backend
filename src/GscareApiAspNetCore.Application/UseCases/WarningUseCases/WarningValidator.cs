using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases;
internal class WarningValidator : AbstractValidator<RequestWarningJson>
{
    public WarningValidator()
    {
        RuleFor(user => user.DataInicial).NotEmpty().WithMessage("É obrigatório informar a data inicial");
        RuleFor(user => user.DataFinal).NotEmpty().WithMessage("É obrigatório informar a data final");
    }
}
