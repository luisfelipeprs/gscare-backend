namespace GscareApiAspNetCore.Domain.Entities;
public class Document
{
    public int Id { get; set; }
    public string? DocumentName { get; set; }
    public string? DocumentImage { get; set; }
    // Remove IFormFile from the entity
}
