using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases
{
    public class GetDocumentByNameUseCase : IGetDocumentByNameUseCase
    {
        private readonly IDocumentRepository _documentRepository;

        public GetDocumentByNameUseCase(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Document?> Execute(string documentName)
        {
            return await _documentRepository.GetDocumentByNameAsync(documentName);
        }
    }
}
