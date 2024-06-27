using GscareApiAspNetCore.Communication.Enums;

namespace GscareApiAspNetCore.Communication.Responses.UserResponses;
public class ResponseShortUserJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public RolesUserType UserType { get; set; }
}
