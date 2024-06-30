using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Entities;
using GscareApiAspNetCore.Domain.Repositories.DocumentRepositories;
using GscareApiAspNetCore.Domain.Repositories.EmployeeRepositories;
using GscareApiAspNetCore.Exception.ExceptionBase;
using GscareApiAspNetCore.Exception;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using GscareApiAspNetCore.Domain.Repositories;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases
{
    public class UploadDocumentUseCase : IUploadDocumentUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDocumentRepository _repository;
        private readonly IWebHostEnvironment _environment;

        public UploadDocumentUseCase(
            IWebHostEnvironment environment,
            IDocumentRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _environment = environment;
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Execute(long Id, DocumentUploadDto documentDto)
        {
            var employee = await _repository.GetById(Id);

            if (employee is null)
            {
                throw new NotFoundException(ResourceErrorMessages.EMPLOYEE_NOT_FOUND);
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

            //var document = new Document
            //{
            //    DocumentName = documentDto.DocumentName,
            //    DocumentImage = uniqueFileName
            //};

           

            // Armazena apenas o nome do arquivo no campo FotoCpf
            employee.FotoCpf = uniqueFileName;

            _mapper.Map(employee, employee);

            _repository.Update(employee);

            await _unitOfWork.Commit();

            //await _documentRepository.SaveDocumentAsync(document);
            return uniqueFileName;
        }
    }
}
