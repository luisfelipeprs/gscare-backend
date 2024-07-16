using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
public interface IDailyReportReadOnlyRepository
{
    Task<List<DailyReport>> GetAll(long appointmentI);
    Task<DailyReport?> GetById(long id);
}
