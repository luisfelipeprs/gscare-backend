using GscareApiAspNetCore.Communication.Responses.DailyReportRepository;

namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public interface IGetAllDailyReportsUseCase
{
    Task<ResponseDailyReportsJson> Execute(long appointmentId);
}
