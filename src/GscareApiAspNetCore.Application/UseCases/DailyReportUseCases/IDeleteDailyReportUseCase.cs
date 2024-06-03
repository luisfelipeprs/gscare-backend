namespace GscareApiAspNetCore.Application.UseCases.DailyReportUseCases;
public interface IDeleteDailyReportUseCase
{
    Task Execute(long id);
}
