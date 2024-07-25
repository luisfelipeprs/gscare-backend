using GscareApiAspNetCore.Api.Attributes;
using GscareApiAspNetCore.Application.UseCases.DocumentUseCases;
using GscareApiAspNetCore.Communication.Requests;
using GscareApiAspNetCore.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        [HttpPost("upload")]
        [AuthenticatedUser]
        public async Task<IActionResult> Upload(
            [FromForm] DocumentUploadDto documentDto,
            [FromServices] IUploadDocumentUseCase uploadDocumentUseCase)
        {
            var filePath = await uploadDocumentUseCase.Execute(documentDto);
            return Ok(new { FilePath = filePath });
        }

        [HttpGet("viewPdf/{fileName}")]
        [AuthenticatedUser]
        public IActionResult ViewPdf(
            [FromRoute] string fileName,
            [FromServices] IWebHostEnvironment environment)
        {
            var uploadsFolder = Path.Combine(environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf");
        }

        [HttpGet("view/{fileName}")]
        [AuthenticatedUser]
        public IActionResult ViewImage(
            [FromRoute] string fileName,
            [FromServices] IWebHostEnvironment environment)
        {
            var uploadsFolder = Path.Combine(environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsFolder, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            var fileExtension = Path.GetExtension(filePath).ToLowerInvariant();
            var mimeType = fileExtension switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream",
            };

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, mimeType);
        }

        [HttpGet("byUser")]
        [AuthenticatedUser]
        public async Task<IActionResult> GetDocumentsByUser(
            //[FromRoute] long userId,
            [FromServices] IGetDocumentsByUserIdUseCase GetDocumentsByUserIdUseCase
            //[FromServices] IGetDocumentUseCase getDocumentUseCase
            )
        {
            var documents = await GetDocumentsByUserIdUseCase.Execute();
            return Ok(documents);
        }

        [HttpGet("all")]
        [AuthenticatedUser]
        public async Task<IActionResult> GetAllDocuments(
            [FromServices] IGetDocumentUseCase getDocumentUseCase)
        {
            var documents = await getDocumentUseCase.GetAllDocumentsAsync();
            return Ok(documents);
        }

        [HttpDelete("delete/{documentId}")]
        [AuthenticatedUser]
        public async Task<IActionResult> DeleteDocument(
            [FromRoute] long documentId,
            [FromServices] IDeleteDocumentUseCase deleteDocumentUseCase)
        {
            await deleteDocumentUseCase.Execute(documentId);
            return NoContent();
        }

        [HttpPut("update/{documentId}")]
        [AuthenticatedUser]
        public async Task<IActionResult> UpdateDocument(
            [FromRoute] long documentId,
            [FromForm] DocumentUpdateDto documentDto,
            [FromServices] IUpdateDocumentUseCase updateDocumentUseCase)
        {
            var document = await updateDocumentUseCase.Execute(documentId, documentDto);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }
    }
}
