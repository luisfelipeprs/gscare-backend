using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
public interface IDailyReportUpdateOnlyRepository
{
    Task<DailyReport?> GetById(long id);
    void Update(DailyReport dailyReport);
}
