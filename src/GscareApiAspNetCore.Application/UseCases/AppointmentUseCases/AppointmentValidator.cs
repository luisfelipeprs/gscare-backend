using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Exception;

namespace GscareApiAspNetCore.Application.UseCases.AppointmentUseCases;
internal class AppointmentValidator : AbstractValidator<RequestAppointmentJson>
{
    public AppointmentValidator()
    {
        RuleFor(appointment => appointment.EmployeeId).NotEmpty().WithMessage("EMPLOYEE_ID_IS_REQUIRED");
        RuleFor(appointment => appointment.PatientId).NotEmpty().WithMessage("PATIENT_ID_IS_REQUIRED");
        RuleFor(appointment => appointment.StartTime).NotEmpty().WithMessage("START_TIME_IS_REQUIRED");
        RuleFor(appointment => appointment.EndTime).NotEmpty().WithMessage("END_TIME_IS_REQUIRED");
        RuleFor(appointment => appointment.StartTime).LessThan(appointment => appointment.EndTime).WithMessage("START_TIME_MUST_BE_BEFORE_END_TIME");
        // Add more validation rules as needed
    }
}