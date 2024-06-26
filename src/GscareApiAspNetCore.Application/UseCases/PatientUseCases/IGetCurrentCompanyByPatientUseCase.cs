using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IGetCurrentCompanyByPatientUseCase
{
    Task<ResponseCompanyJson> Execute();

}
