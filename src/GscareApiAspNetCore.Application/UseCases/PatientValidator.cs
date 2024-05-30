using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases;
internal class PatientValidator : AbstractValidator<RequestPatientJson>
{
    public PatientValidator()
    {
        RuleFor(patient => patient.NomeCompleto).NotEmpty().WithMessage(ResourceErrorMessages.FULL_NAME_IS_REQUIRED);
    }
}
