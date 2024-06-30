using GscareApiAspNetCore.Communication.Enums;
using Microsoft.AspNetCore.Http;

namespace GscareApiAspNetCore.Communication.Requests;
public class RequestEmployeeJson
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Identidade { get; set; } = string.Empty;
    public string EnderecoComCep { get; set; } = string.Empty;
    public DisponibilidadeDeHorarioType DisponibilidadeDeHorario { get; set; }

    // Fotos
    public string FotoIdentidade { get; set; } = string.Empty;
    public string FotoCpf { get; set; } = string.Empty;
    public string FotoComprovanteResidencia { get; set; } = string.Empty;
    public string FotoCertificadoDoCurso { get; set; } = string.Empty;
    public string FotoMei { get; set; } = string.Empty;
    public string FotoNadaConsta { get; set; } = string.Empty;
}
