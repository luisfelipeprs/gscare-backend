namespace GscareApiAspNetCore.Domain.Entities;
public class Service
{
    public long Id { get; set; }
    public string Patient { get; set; } = string.Empty;
    public string Employee { get; set; } = string.Empty;
    public string InicioService { get; set; } = string.Empty;
    public string FimService { get; set; } = string.Empty;
    public string? Descricao { get; set; } = string.Empty;
}
