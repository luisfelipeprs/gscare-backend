using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using GscareApiAspNetCore.Domain.Repositories.UserRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using System;
using System.IO;
using System.Threading.Tasks;
using GscareApiAspNetCore.Domain.Services.LoggedUser;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases
{
    public class UploadDocumentUseCase : IUploadDocumentUseCase
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _repository;
        private readonly IUserReadOnlyRepository _userRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly ILoggedUser _loggedUser;

        public UploadDocumentUseCase(
            IWebHostEnvironment environment,
            IDocumentRepository repository,
            IUserReadOnlyRepository userRepository,
            IMapper mapper,
            ILoggedUser loggedUser)
        {
            _environment = environment;
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<string> Execute(DocumentUploadDto documentDto)
        {

            var loggedInUser = await _loggedUser.User();
            var userId = loggedInUser.Id;

            var user = await _userRepository.GetById(userId);

            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            if (documentDto.ImageFile == null || documentDto.ImageFile.Length == 0)
            {
                throw new ArgumentException("Image file is not provided.");
            }

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(documentDto.ImageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await documentDto.ImageFile.CopyToAsync(fileStream);
            }

            var document = new Document
            {
                DocumentName = documentDto.DocumentName,
                DocumentImage = uniqueFileName,
                UserId = userId
            };

            await _repository.SaveDocumentAsync(document);

            return uniqueFileName;
        }
    }
}
