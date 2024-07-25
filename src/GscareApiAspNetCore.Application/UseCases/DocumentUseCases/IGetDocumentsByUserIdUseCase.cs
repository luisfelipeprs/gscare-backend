using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
public interface IGetDocumentsByUserIdUseCase
{
    Task<IEnumerable<Document>> Execute();
}