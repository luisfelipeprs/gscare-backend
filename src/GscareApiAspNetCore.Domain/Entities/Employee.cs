using GscareApiAspNetCore.Domain.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GscareApiAspNetCore.Domain.Entities;
public class Employee
{
    public long Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Identidade { get; set; } = string.Empty;
    public string EnderecoComCep { get; set; } = string.Empty;
    public DisponibilidadeDeHorarioType DisponibilidadeDeHorario { get; set; }
    public string? FotoIdentidade { get; set; }
    public string? FotoCpf { get; set; }
    public string? FotoComprovanteResidencia { get; set; }
    public string? CertificadoDoCurso { get; set; }
    public string? Mei { get; set; }
    public string? NadaConsta { get; set; }

    // Relacionamento
    public long? CurrentCompanyId { get; set; }
    public Company? CurrentCompany { get; set; }
    public User? User { get; set; }

    // Adicionar esta propriedade
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

}
