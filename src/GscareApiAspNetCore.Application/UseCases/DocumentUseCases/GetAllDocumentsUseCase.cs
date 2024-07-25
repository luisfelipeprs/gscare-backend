using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases
{
    public class GetAllDocumentsUseCase : IGetAllDocumentsUseCase
    {
        private readonly IDocumentRepository _documentRepository;

        public GetAllDocumentsUseCase(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<IEnumerable<Document>> Execute()
        {
            return await _documentRepository.GetAllDocumentsAsync();
        }
    }
}
