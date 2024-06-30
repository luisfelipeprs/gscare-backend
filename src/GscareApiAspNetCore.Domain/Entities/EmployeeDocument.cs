using GscareApiAspNetCore.Domain.Enums;

namespace GscareApiAspNetCore.Domain.Entities;
public class EmployeeDocument
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public DocumentType DocumentType { get; set; }
    public string DocumentFileName { get; set; } = string.Empty;
}