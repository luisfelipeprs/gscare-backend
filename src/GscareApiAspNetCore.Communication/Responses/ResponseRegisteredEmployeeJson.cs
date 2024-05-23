namespace GscareApiAspNetCore.Communication.Responses;
public class ResponseRegisteredEmployeeJson
{
    public string NomeCompleto { get; set; } = string.Empty;
    public ResponseTokenJson Tokens { get; set; } = default!;
}
