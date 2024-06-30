using GscareApiAspNetCore.Communication.Enums;

namespace GscareApiAspNetCore.Communication.Responses.EmployeeResponses;
public class ResponseEmployeeJson
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
    public string? FotoCertificadoDoCurso { get; set; }
    public string? FotoMei { get; set; }
    public string? FotoNadaConsta { get; set; }

    // Adicione essa propriedade se desejado
    //public ResponseCompanyJson? CurrentCompany { get; set; }
    public long CurrentCompanyId { get; set; }
}
