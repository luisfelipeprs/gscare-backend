using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
public interface IGetDocumentByNameUseCase
{
    Task<Document?> Execute(string documentName);
}