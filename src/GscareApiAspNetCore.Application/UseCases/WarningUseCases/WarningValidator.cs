using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases;
internal class WarningValidator : AbstractValidator<RequestWarningJson>
{
    public WarningValidator()
    {
        RuleFor(warning => warning.Titulo).NotEmpty().WithMessage("É obrigatório informar o título");
        RuleFor(warning => warning.AvisoType).NotEmpty().WithMessage("É obrigatório informar o tipo do aviso");
        RuleFor(warning => warning.DataInicial).NotEmpty().WithMessage("É obrigatório informar a data inicial");
        RuleFor(warning => warning.DataFinal).NotEmpty().WithMessage("É obrigatório informar a data final");
        RuleFor(warning => warning.Mensagem).NotEmpty().WithMessage("É obrigatório informar a mensagem");
    }
}
