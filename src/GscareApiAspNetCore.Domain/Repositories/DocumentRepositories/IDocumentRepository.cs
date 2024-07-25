using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;

public interface IDocumentRepository
{
    Task<Document?> GetDocumentByIdAsync(long id);
    Task<Document?> GetDocumentByNameAsync(string documentName);
    Task<IEnumerable<Document>> GetDocumentsByUserIdAsync(long userId);
    Task SaveDocumentAsync(Document document);
    void Update(Document document);
    Task DeleteDocumentAsync(long id);
    Task<IEnumerable<Document>> GetAllDocumentsAsync();
}