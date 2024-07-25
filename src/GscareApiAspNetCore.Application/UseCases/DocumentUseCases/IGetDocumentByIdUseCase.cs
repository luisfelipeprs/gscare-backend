using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
public interface IGetDocumentByIdUseCase
{
    Task<Document?> Execute(long id);
}