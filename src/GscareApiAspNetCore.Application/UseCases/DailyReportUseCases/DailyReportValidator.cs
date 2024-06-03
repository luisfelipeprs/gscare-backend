using FluentValidation;
using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public class DailyReportValidator : AbstractValidator<RequestDailyReportJson>
{
    public DailyReportValidator()
    {
        RuleFor(user => user.Patient).NotEmpty().WithMessage("É obrigatório informar o Patient");
        RuleFor(user => user.Employee).NotEmpty().WithMessage("É obrigatório informar o Employee");
        RuleFor(user => user.Title).NotEmpty().WithMessage("É obrigatório informar o Title");
        RuleFor(user => user.Description).NotEmpty().WithMessage("É obrigatório informar o Description");
    }
}
