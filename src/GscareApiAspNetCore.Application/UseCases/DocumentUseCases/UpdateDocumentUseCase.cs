using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using GscareApiAspNetCore.Domain.Services.LoggedUser;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases
{
    public class UpdateDocumentUseCase : IUpdateDocumentUseCase
    {
        private readonly IDocumentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        private readonly ILoggedUser _loggedUser;

        public UpdateDocumentUseCase(IDocumentRepository repository, IUnitOfWork unitOfWork, IWebHostEnvironment environment, ILoggedUser loggedUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _environment = environment;
            _loggedUser = loggedUser;
        }

        public async Task<Document?> Execute(long documentId, DocumentUpdateDto documentDto)
        {

            var loggedInUser = await _loggedUser.User();
            var companyId = loggedInUser.CompanyId;

            var existingDocument = await _repository.GetDocumentByIdAsync(documentId);
            if (existingDocument == null)
            {
                return null;
            }

            // Remover o arquivo antigo
            if (!string.IsNullOrEmpty(existingDocument.DocumentImage))
            {
                var oldFilePath = Path.Combine(_environment.WebRootPath, "uploads", existingDocument.DocumentImage);
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }
            }

            // Salvar o novo arquivo
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(documentDto.ImageFile!.FileName);
            var newFilePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(newFilePath, FileMode.Create))
            {
                await documentDto.ImageFile.CopyToAsync(stream);
            }

            // Atualizar o documento
            existingDocument.DocumentName = documentDto.DocumentName;
            existingDocument.DocumentImage = uniqueFileName;

            _repository.Update(existingDocument);
            await _unitOfWork.Commit();

            return existingDocument;
        }
    }
}
