using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System;
using GscareApiAspNetCore.Application.UseCases.EmployeeUseCases;

namespace GscareApiAspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {

        private readonly IWebHostEnvironment _environment;
        private readonly IUploadDocumentUseCase _uploadDocumentUseCase;
        private readonly IGetDocumentUseCase _getDocumentUseCase;
        
        public DocumentController(IUploadDocumentUseCase uploadDocumentUseCase, IGetDocumentUseCase getDocumentUseCase, IWebHostEnvironment environment)
        {
            _environment = environment;
            _uploadDocumentUseCase = uploadDocumentUseCase;
            _getDocumentUseCase = getDocumentUseCase;
        }

        [HttpPost("upload/{id}")]
        public async Task<IActionResult> Upload(
        [FromForm] DocumentUploadDto documentDto,
        [FromRoute] long id)
        {
            var filePath = await _uploadDocumentUseCase.Execute(id, documentDto);
            return Ok(new { FilePath = filePath });
        }


        // Endpoint para visualização de arquivos PDF
        [HttpGet("viewPdf/{fileName}")]
        public IActionResult ViewPdf(string fileName)
        {
            // Caminho completo do arquivo PDF
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            // Verifica se o arquivo existe
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            // Lê os bytes do arquivo PDF e retorna um FileContentResult com tipo de conteúdo application/pdf
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf");
        }


        // Endpoint para visualização de imagens
        [HttpGet("view/{fileName}")]
        public IActionResult ViewImage(string fileName)
        {
            // Caminho completo do arquivo de imagem
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            // Verifica se o arquivo existe
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            // Determina o tipo MIME da imagem com base na extensão do arquivo
            var fileExtension = Path.GetExtension(filePath).ToLowerInvariant();
            var mimeType = fileExtension switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream", // Caso não seja uma imagem, assume um tipo de conteúdo genérico
            };

            // Lê os bytes do arquivo de imagem e retorna um FileContentResult
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, mimeType);
        }

        //[HttpGet("view/{documentName}")]
        //public async Task<IActionResult> ViewImage(string documentName)
        //{
        //    var document = await _getDocumentUseCase.Execute(documentName);
        //    if (document == null)
        //    {
        //        return NotFound("Document not found.");
        //    }

        //    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
        //    var filePath = Path.Combine(uploadsFolder, document.DocumentImage!);

        //    if (!System.IO.File.Exists(filePath))
        //    {
        //        return NotFound("File not found.");
        //    }

        //    var fileExtension = Path.GetExtension(filePath).ToLowerInvariant();
        //    var mimeType = fileExtension switch
        //    {
        //        ".jpg" => "image/jpeg",
        //        ".jpeg" => "image/jpeg",
        //        ".png" => "image/png",
        //        ".gif" => "image/gif",
        //        _ => "application/octet-stream",
        //    };

        //    var fileBytes = System.IO.File.ReadAllBytes(filePath);
        //    return File(fileBytes, mimeType);
        //}

    }
}
