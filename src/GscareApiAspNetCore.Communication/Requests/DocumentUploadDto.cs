using Microsoft.AspNetCore.Http;

namespace GscareApiAspNetCore.Communication.Requests
{
    public class DocumentUploadDto
    {
        public string? DocumentName { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
