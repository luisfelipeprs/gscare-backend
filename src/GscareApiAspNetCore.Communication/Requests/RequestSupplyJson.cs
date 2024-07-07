namespace GscareApiAspNetCore.Communication.Requests;
public class RequestSupplyJson
{
    public string Nome { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public DateTime Data { get; set; }
}
