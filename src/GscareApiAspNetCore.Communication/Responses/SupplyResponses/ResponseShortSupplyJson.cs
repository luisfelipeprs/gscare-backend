namespace GscareApiAspNetCore.Communication.Responses.SupplyResponses;
public class ResponseShortSupplyJson
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public DateTime Data { get; set; }
}
