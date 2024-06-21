using GscareApiAspNetCore.Communication.Enums;

namespace GscareApiAspNetCore.Communication.Requests;
public class RequestUserJson
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public RolesUserType UserType { get; set; }
    public DateTime DateOfBirth { get; set; }
    public GenderUserType Gender { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }

    // Propriedades específicas de cada tipo de usuário
    public RequestEmployeeJson? Employee { get; set; }
    public RequestPatientJson? Patient { get; set; }
    public RequestCompanyJson? Company { get; set; }
}
