using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
internal interface IGetDocumentsByUserId
{
    Task<IEnumerable<Document>> Execute();
}
