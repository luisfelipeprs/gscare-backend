namespace GscareApiAspNetCore.Communication.Responses;
public class ResponsePatientJson
{
    public long Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public int Idade { get; set; }
    public string Patologia { get; set; } = string.Empty;
    public string EnderecoDeAtendimentoComCep { get; set; } = string.Empty;
    public string NomeCompletoDoResponsavelFinanceiro { get; set; } = string.Empty;
    public string DataDePagamento { get; set; } = string.Empty;
    public string FormaDePagamento { get; set; } = string.Empty;
    public string GrauDeParentesco { get; set; } = string.Empty;
    public string Identidade { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;

    // Adicione essa propriedade se desejado
    //public ResponseCompanyJson? CurrentCompany { get; set; }
    public long CurrentCompanyId { get; set; }
}
