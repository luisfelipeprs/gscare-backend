using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.AppointmentResponses;

namespace GscareApiAspNetCore.Application.UseCases.AppointmentUseCases;
public interface IUpdateAppointmentUseCase
{
    Task Execute(long id, RequestAppointmentJson request);
}