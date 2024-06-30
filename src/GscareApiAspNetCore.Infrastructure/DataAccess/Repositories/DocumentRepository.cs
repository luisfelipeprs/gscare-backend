using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using Microsoft.EntityFrameworkCore;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories;
internal class DocumentRepository : IDocumentRepository
{
    private readonly GsCareDbContext _dbContext;

    public async Task<Employee?> GetById(long id)
    {
        return await _dbContext.Employees.FindAsync(id);
    }

    public void Update(Employee employee)
    {
        _dbContext.Employees.Update(employee);
    }

    public DocumentRepository(GsCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveDocumentAsync(Document document)
    {
        _dbContext.Documents.Add(document);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Document?> GetDocumentByIdAsync(long id)
    {
        return await _dbContext.Documents.FindAsync(id);
    }

    public async Task<Document?> GetDocumentByNameAsync(string documentName)
    {
        return await _dbContext.Documents.FirstOrDefaultAsync(d => d.DocumentName == documentName);
    }
}