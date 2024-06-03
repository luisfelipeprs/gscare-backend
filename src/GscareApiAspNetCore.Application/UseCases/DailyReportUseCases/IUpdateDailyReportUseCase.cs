using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public interface IUpdateDailyReportUseCase
{
    Task Execute(long Id, RequestDailyReportJson request);
}
