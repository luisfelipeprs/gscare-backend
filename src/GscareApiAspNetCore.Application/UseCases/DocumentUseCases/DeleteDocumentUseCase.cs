using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using Microsoft.AspNetCore.Hosting;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases
{
    public class DeleteDocumentUseCase : IDeleteDocumentUseCase
    {
        private readonly IDocumentRepository _repository;
        private readonly IWebHostEnvironment _environment;
        private readonly ILoggedUser _loggedUser;

        public DeleteDocumentUseCase(IDocumentRepository repository, IWebHostEnvironment environment, ILoggedUser loggedUser)
        {
            _repository = repository;
            _environment = environment;
            _loggedUser = loggedUser;
        }

        public async Task Execute(long documentId)
        {

            var loggedInUser = await _loggedUser.User();
            var companyId = loggedInUser.CompanyId;

            var document = await _repository.GetDocumentByIdAsync(documentId);
            if (document != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploadsFolder, document.DocumentImage!);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                await _repository.DeleteDocumentAsync(documentId);
            }
        }
    }
}
