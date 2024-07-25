using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Infrastructure.DataAccess.Repositories
{
    internal class DocumentRepository : IDocumentRepository
    {
        private readonly GsCareDbContext _dbContext;

        public DocumentRepository(GsCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Document?> GetDocumentByIdAsync(long id)
        {
            return await _dbContext.Documents.FindAsync(id);
        }

        public async Task<Document?> GetDocumentByNameAsync(string documentName)
        {
            return await _dbContext.Documents.FirstOrDefaultAsync(d => d.DocumentName == documentName);
        }

        public async Task<IEnumerable<Document>> GetDocumentsByUserIdAsync(long userId)
        {
            return await _dbContext.Documents.Where(d => d.UserId == userId).ToListAsync();
        }

        public async Task SaveDocumentAsync(Document document)
        {
            _dbContext.Documents.Add(document);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(Document document)
        {
            _dbContext.Documents.Update(document);
        }

        public async Task DeleteDocumentAsync(long id)
        {
            var document = await _dbContext.Documents.FindAsync(id);
            if (document != null)
            {
                _dbContext.Documents.Remove(document);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _dbContext.Documents.ToListAsync();
        }
    }
}
