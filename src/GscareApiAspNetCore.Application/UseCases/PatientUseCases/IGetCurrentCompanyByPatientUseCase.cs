using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses.CompanyResponses;

namespace GscareApiAspNetCore.Application.UseCases.PatientUseCases;
public interface IGetCurrentCompanyByPatientUseCase
{
    Task<ResponseCompanyJson> Execute();

}
