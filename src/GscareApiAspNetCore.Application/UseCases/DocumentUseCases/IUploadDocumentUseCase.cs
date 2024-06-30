using GscareApiAspNetCore.Communication.Requests;

namespace GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
public interface IUploadDocumentUseCase
{
    Task<string> Execute(long Id, DocumentUploadDto documentDto);
}