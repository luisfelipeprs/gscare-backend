namespace GscareApiAspNetCore.Communication.Responses.AppointmentsResponses;
public class ResponseShortAppointmentJson
{
    public long Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
}
