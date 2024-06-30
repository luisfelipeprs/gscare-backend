using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
public interface IDocumentRepository
{
    Task<Employee?> GetById(long id);
    void Update(Employee employee);
    Task SaveDocumentAsync(Document document);
    Task<Document?> GetDocumentByIdAsync(long id);
    Task<Document?> GetDocumentByNameAsync(string documentName);
}