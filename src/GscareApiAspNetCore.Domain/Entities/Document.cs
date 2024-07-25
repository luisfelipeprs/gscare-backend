namespace GscareApiAspNetCore.Domain.Entities;
public class Document
{
    public long Id { get; set; }
    public string? DocumentType { get; set; }
    public string? DocumentName { get; set; }
    public string? DocumentPath { get; set; }
    public string? DocumentImage { get; set; }
    public long UserId { get; set; }

    // Navigation property
    public User User { get; set; } = null!;
}
