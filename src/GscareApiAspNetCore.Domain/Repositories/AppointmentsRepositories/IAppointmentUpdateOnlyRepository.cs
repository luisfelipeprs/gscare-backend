using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
public interface IAppointmentUpdateOnlyRepository
{
    Task<Appointment?> GetById(long id);
    void Update(Appointment appointment);
}