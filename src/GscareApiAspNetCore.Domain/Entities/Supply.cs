namespace GscareApiAspNetCore.Domain.Entities;
public class Supply
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public string Quantidade { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
}
