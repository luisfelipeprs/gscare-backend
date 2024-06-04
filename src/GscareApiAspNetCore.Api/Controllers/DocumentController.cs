using Microsoft.AspNetCore.Mvc;

namespace GscareApiAspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        // Dependência para acessar o ambiente de hospedagem
        private readonly IWebHostEnvironment _environment;

        // Construtor que injeta a dependência IWebHostEnvironment
        public DocumentController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // Endpoint para upload de documentos
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] DocumentUploadDto documentDto)
        {
            // Verifica se o arquivo de imagem foi fornecido
            if (documentDto.ImageFile == null || documentDto.ImageFile.Length == 0)
            {
                return BadRequest("Image file is not provided.");
            }

            // Diretório onde os uploads serão armazenados
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

            // Cria o diretório se não existir
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Obtenção da extensão do arquivo
            var fileExtension = Path.GetExtension(documentDto.ImageFile.FileName).ToLowerInvariant();

            // Geração de um nome de arquivo único
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(documentDto.ImageFile.FileName);

            // Caminho completo do arquivo
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Copia o arquivo de imagem para o diretório de uploads
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await documentDto.ImageFile.CopyToAsync(fileStream);
            }

            // Aqui você pode adicionar lógica para salvar as informações do documento no banco de dados, se necessário

            // Retorna um OkResult com o caminho do arquivo
            return Ok(new { FilePath = filePath });
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
    }

    // DTO para upload de documentos
    public class DocumentUploadDto
    {
        public string? DocumentName { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
