using GscareApiAspNetCore.Communication.Enums;

namespace GscareApiAspNetCore.Communication.Responses;
public class ResponseUserJson
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
}