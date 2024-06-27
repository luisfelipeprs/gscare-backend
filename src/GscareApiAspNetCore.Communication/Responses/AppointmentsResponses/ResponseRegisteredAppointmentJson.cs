namespace GscareApiAspNetCore.Communication.Responses.AppointmentResponses
{
    public class ResponseRegisteredAppointmentJson
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long PatientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
