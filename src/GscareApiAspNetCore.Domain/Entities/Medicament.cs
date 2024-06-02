namespace GscareApiAspNetCore.Domain.Entities;
public class Medicament
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Amount { get; set; } = string.Empty;
    public string Hours { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
}
