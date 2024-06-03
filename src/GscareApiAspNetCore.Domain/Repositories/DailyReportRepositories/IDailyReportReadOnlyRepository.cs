using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
public interface IDailyReportReadOnlyRepository
{
    Task<List<DailyReport>> GetAll();
    Task<DailyReport?> GetById(long id);
}
