using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases;
public class RegisterEmployeeValidator: AbstractValidator<RequestRegisterEmployeeJson>
{
    public RegisterEmployeeValidator()
    {
        RuleFor(employee => employee.NomeCompleto).NotEmpty().WithMessage(ResourceErrorMessages.FULL_NAME_IS_REQUIRED);
        RuleFor(employee => employee.DisponibilidadeDeHorario).IsInEnum().WithMessage(ResourceErrorMessages.TIME_AVAILABILITY_TYPE_IS_NOT_VALID_);
    }
}
