namespace GscareApiAspNetCore.Communication.Responses.WarningResponses;
public class ResponseWarningJson
{
    public string Titulo { get; set; } = string.Empty;
    public string AvisoType { get; set; } = string.Empty;
    public DateTime DataInicial { get; set; }
    public DateTime DataFinal { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public long CompanyId { get; set; }
}

