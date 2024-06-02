using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.MedicamentUseCases;
internal class MedicamentValidator : AbstractValidator<RequestMedicamentJson>
{
    public MedicamentValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("É obrigatório informar o nome");
        RuleFor(user => user.Amount).NotEmpty().WithMessage("É obrigatório informar a quantidade");
        RuleFor(user => user.Frequency).NotEmpty().WithMessage("É obrigatório informar a frequencia de medicacao");
        RuleFor(user => user.Hours).NotEmpty().WithMessage("É obrigatório informar a hora da medicacao");
    }
}
