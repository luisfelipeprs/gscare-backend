using GscareApiAspNetCore.Communication.Enums;

namespace GscareApiAspNetCore.Communication.Requests;
public class RequestRegisterEmployeeJson
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
    public string CertificadoDoCurso { get; set; } = string.Empty;
    public string Mei { get; set; } = string.Empty;
    public string NadaConsta { get; set; } = string.Empty;
}
