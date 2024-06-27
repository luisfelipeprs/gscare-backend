namespace GscareApiAspNetCore.Communication.Responses.PatientResponses;
public class ResponseShortPatientJson
{
    public long Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Patologia { get; set; } = string.Empty;
    public string EnderecoDeAtendimentoComCep { get; set; } = string.Empty;
}
