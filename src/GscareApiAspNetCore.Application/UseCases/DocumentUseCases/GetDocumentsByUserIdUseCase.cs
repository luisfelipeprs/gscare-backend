using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases
{
    public class GetDocumentsByUserIdUseCase : IGetDocumentsByUserIdUseCase
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ILoggedUser _loggedUser;


        public GetDocumentsByUserIdUseCase(IDocumentRepository documentRepository, ILoggedUser loggedUser)
        {
            _documentRepository = documentRepository;
            _loggedUser = loggedUser;
        }

        public async Task<IEnumerable<Document>> Execute()
        {
            var loggedInUser = await _loggedUser.User();
            var userId = loggedInUser.Id;

            return await _documentRepository.GetDocumentsByUserIdAsync(userId);
        }
    }
}
