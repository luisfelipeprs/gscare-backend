using GscareApiAspNetCore.Domain.Enums;

namespace GscareApiAspNetCore.Domain.Entities;
public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public RolesUserType UserType { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderUserType Gender { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }

    // Nullable foreign keys
    public long? EmployeeId { get; set; }
    public long? PatientId { get; set; }
    public long? CompanyId { get; set; }

    // Navigation properties
    public Employee? Employee { get; set; }
    public Patient? Patient { get; set; }
    public Company? Company { get; set; }

    // Relationship with Document
    public ICollection<Document> Documents { get; set; } = new List<Document>();
}
