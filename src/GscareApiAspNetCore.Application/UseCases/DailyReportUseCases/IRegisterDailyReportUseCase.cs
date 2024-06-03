using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.DailyReportRepository;

namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public interface IRegisterDailyReportUseCase
{
    Task<ResponseRegisteredDailyReportJson> Execute(RequestDailyReportJson request);
}
