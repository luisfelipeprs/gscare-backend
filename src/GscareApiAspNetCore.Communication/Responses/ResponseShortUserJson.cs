using GscareApiAspNetCore.Communication.Enums;

namespace GscareApiAspNetCore.Communication.Responses;
public class ResponseShortUserJson
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserTypeType UserType { get; set; }
}
