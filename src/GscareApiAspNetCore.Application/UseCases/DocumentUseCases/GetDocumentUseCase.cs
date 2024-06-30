using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
public class GetDocumentUseCase : IGetDocumentUseCase
{
    private readonly IDocumentRepository _documentRepository;

    public GetDocumentUseCase(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<Document?> Execute(string documentName)
    {
        return await _documentRepository.GetDocumentByNameAsync(documentName);
    }
}