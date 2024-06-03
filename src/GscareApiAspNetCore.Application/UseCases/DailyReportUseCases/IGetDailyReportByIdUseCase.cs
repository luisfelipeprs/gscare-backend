using GscareApiAspNetCore.Communication.Responses.DailyReportRepository;

namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public interface IGetDailyReportByIdUseCase
{
    Task<ResponseDailyReportJson> Execute(long id);
}
