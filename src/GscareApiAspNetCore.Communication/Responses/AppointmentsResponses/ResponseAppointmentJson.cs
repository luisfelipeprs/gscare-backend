namespace GscareApiAspNetCore.Communication.Responses.AppointmentResponses
{
    public class ResponseAppointmentJson
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long PatientId { get; set; }
        public long CompanyId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
