using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases;
internal class CompanyValidator : AbstractValidator<RequestCompanyJson>
{
    public CompanyValidator()
    {
        RuleFor(user => user.NomeDaEmpresa).NotEmpty().WithMessage(ResourceErrorMessages.FULL_NAME_IS_REQUIRED);
        RuleFor(user => user.Cnpj).NotEmpty().WithMessage(ResourceErrorMessages.TIME_AVAILABILITY_TYPE_IS_NOT_VALID_);
    }
}
