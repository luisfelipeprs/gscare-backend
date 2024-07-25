using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases
{
    public class GetDocumentByIdUseCase : IGetDocumentByIdUseCase
    {
        private readonly IDocumentRepository _documentRepository;

        public GetDocumentByIdUseCase(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<Document?> Execute(long id)
        {
            return await _documentRepository.GetDocumentByIdAsync(id);
        }
    }
}
