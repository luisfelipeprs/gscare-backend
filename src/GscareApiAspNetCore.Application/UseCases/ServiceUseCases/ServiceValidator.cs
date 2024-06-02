using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.ServiceUseCases;
internal class ServiceValidator : AbstractValidator<RequestServiceJson>
{
    public ServiceValidator()
    {
        RuleFor(user => user.Employee).NotEmpty().WithMessage("É obrigatório informar o Employee");
        RuleFor(user => user.Patient).NotEmpty().WithMessage("É obrigatório informar o Patient");
    }
}
