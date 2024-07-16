namespace GscareApiAspNetCore.Domain.Entities;
public class Appointment
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long PatientId { get; set; }
    public long CompanyId { get; set; } 
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Description { get; set; }

    // Relacionamentos
    public Employee Employee { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
    public Company Company { get; set; } = null!;

    public ICollection<DailyReport> DailyReports { get; set; } = new List<DailyReport>();

}