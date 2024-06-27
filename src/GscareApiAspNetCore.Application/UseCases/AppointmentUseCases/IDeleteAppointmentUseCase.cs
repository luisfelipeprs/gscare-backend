using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.AppointmentUseCases
{
    public interface IDeleteAppointmentUseCase
    {
        Task Execute(long id);
    }
}
