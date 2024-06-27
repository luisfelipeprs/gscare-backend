using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
public interface IAppointmentReadOnlyRepository
{
    Task<List<Appointment>> GetAll();
    Task<Appointment?> GetById(long id);
}