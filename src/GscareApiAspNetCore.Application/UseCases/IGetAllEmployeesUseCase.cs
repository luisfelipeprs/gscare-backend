using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Communication.Responses;
using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Application.UseCases;
public interface IGetAllEmployeesUseCase
{
    Task<ResponseEmployeesJson> Execute();
}
