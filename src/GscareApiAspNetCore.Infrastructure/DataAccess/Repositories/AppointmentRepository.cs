using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories
{
    internal class AppointmentRepository : IAppointmentReadOnlyRepository, IAppointmentUpdateOnlyRepository, IAppointmentWriteOnlyRepository
    {
        private readonly GsCareDbContext _dbContext;

        public AppointmentRepository(GsCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _dbContext.Appointments
                .Include(a => a.Employee)
                .Include(a => a.Patient)
                .Include(a => a.Company) // Include company
                .ToListAsync();            
        }

        async Task<Appointment?> IAppointmentReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Appointments
                .Include(a => a.Employee)
                .Include(a => a.Patient)
                .Include(a => a.Company) // Include company
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        async Task<Appointment?> IAppointmentUpdateOnlyRepository.GetById(long id)
        {
            return await _dbContext.Appointments
                .Include(a => a.Employee)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Update(Appointment appointment)
        {
            _dbContext.Appointments.Update(appointment);
            _dbContext.SaveChanges();
        }

        public async Task Add(Appointment appointment)
        {
            await _dbContext.Appointments.AddAsync(appointment);
        }

        public async Task<bool> Delete(long id)
        {
            var appointment = await _dbContext.Appointments.FindAsync(id);
            if (appointment == null)
                return false;

            _dbContext.Appointments.Remove(appointment);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsAppointmentOverlap(DateTime startTime, DateTime endTime, long employeeId, long patientId)
        {
            return await _dbContext.Appointments
                .AnyAsync(a => a.EmployeeId == employeeId && a.PatientId == patientId &&
                               ((startTime >= a.StartTime && startTime < a.EndTime) ||
                                (endTime > a.StartTime && endTime <= a.EndTime) ||
                                (startTime <= a.StartTime && endTime >= a.EndTime)));
        }
    }
}
