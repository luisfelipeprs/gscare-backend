namespace GscareApiAspNetCore.Communication.Requests;
public class RequestCompanyJson
{
    public string NomeDaEmpresa { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string TipoDeEscala { get; set; } = string.Empty;
    public string ValorPagoMensal { get; set; } = string.Empty;
    public string ValorDoPlantaoDaProfissional { get; set; } = string.Empty;
}
