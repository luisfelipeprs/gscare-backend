namespace GscareApiAspNetCore.Domain.Entities;
public class Warning
{
    public long Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string AvisoType { get; set; } = string.Empty;
    public string DataInicial {  get; set; } = string.Empty;
    public string DataFinal { get; set; } = string.Empty;
    public string Mensagem {  get; set; } = string.Empty;
}
