namespace GscareApiAspNetCore.Domain.Entities;
public class Supply
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public DateTime Data { get; set; }
    public long PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
}
