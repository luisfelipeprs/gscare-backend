namespace GscareApiAspNetCore.Communication.Requests
{
    public class RequestAppointmentJson
    {
        public long EmployeeId { get; set; }
        public long PatientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
