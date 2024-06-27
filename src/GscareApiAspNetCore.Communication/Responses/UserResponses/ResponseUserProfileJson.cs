using GscareApiAspNetCore.Communication.Enums;
using GscareApiAspNetCore.Communication.Responses.CompanyResponses;
using GscareApiAspNetCore.Communication.Responses.EmployeeResponses;
using GscareApiAspNetCore.Communication.Responses.PatientResponses;

namespace GscareApiAspNetCore.Communication.Responses.UserResponses;
public class ResponseUserProfileJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public RolesUserType UserType { get; set; }
    public ResponseEmployeeJson? Employee { get; set; }
    public ResponsePatientJson? Patient { get; set; }
    public ResponseCompanyJson? Company { get; set; }
}
