using GscareApiAspNetCore.Domain.Enums;

namespace GscareApiAspNetCore.Domain.Entities;
public class Employee
{
    public long Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Identidade { get; set; } = string.Empty;
    public string EnderecoComCep { get; set; } = string.Empty;
    public DisponibilidadeDeHorarioType DisponibilidadeDeHorario { get; set; }

    // Imagens (fotos)
    public string FotoIdentidade { get; set; } = string.Empty;
    public string FotoCpf { get; set; } = string.Empty;
    public string FotoComprovanteResidencia { get; set; } = string.Empty;
    public string FotoCertificadoDoCurso { get; set; } = string.Empty;
    public string FotoMei { get; set; } = string.Empty;
    public string FotoNadaConsta { get; set; } = string.Empty;

    // Relacionamento
    public long? CurrentCompanyId { get; set; }
    public Company? CurrentCompany { get; set; }
    public User? User { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

}
