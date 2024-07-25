// DTO para atualização de documento
using Microsoft.AspNetCore.Http;

namespace GscareApiAspNetCore.Communication.Requests
{
    public class DocumentUpdateDto
    {
        public string? DocumentName { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
