using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.AppointmentsRepositories;
public interface IAppointmentWriteOnlyRepository
{
    Task Add(Appointment appointment);
    /// <summary>
    /// This function returns TRUE if the deletion was successful otherwise returns FALSE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
    Task<bool> IsAppointmentOverlap(DateTime startTime, DateTime endTime, long employeeId, long patientId);
}
