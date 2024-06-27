using GscareApiAspNetCore.Communication.Responses.AppointmentResponses;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.AppointmentUseCases
{
    public interface IGetAllAppointmentsUseCase
    {
        Task<ResponseAppointmentsJson> Execute();
    }
}
