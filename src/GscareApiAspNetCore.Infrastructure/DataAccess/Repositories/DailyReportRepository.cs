using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DailyReportRepositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class DailyReportRepository : IDailyReportReadOnlyRepository, IDailyReportUpdateOnlyRepository, IDailyReportWriteOnlyRepository
{
    private readonly GsCareDbContext _dbContext;

    public DailyReportRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(DailyReport dailyReport)
    {
        await _dbContext.DailyReports.AddAsync(dailyReport);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.DailyReports.FirstOrDefaultAsync(DailyReport => DailyReport.Id == id);

        if (result is null)
        {
            return false;
        }

        _dbContext.DailyReports.Remove(result);

        return true;
    }

    public async Task<List<DailyReport>> GetAll(long appointmentId)
    {
        return await _dbContext.DailyReports
            .AsNoTracking()
            .Where(dr => dr.AppointmentId == appointmentId)
            .ToListAsync();

        //return await _dbContext.DailyReports.AsNoTracking().ToListAsync();
        //await _dbContext.DailyReports.Where(e => e.UserId == id)
    }

    async Task<DailyReport?> IDailyReportReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.DailyReports.AsNoTracking().FirstOrDefaultAsync(DailyReport => DailyReport.Id == id);
    }

    async Task<DailyReport?> IDailyReportUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.DailyReports.FirstOrDefaultAsync(DailyReport => DailyReport.Id == id);
    }

    public void Update(DailyReport dailyReport)
    {
        _dbContext.DailyReports.Update(dailyReport);
    }
}
