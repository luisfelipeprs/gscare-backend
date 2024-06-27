namespace GscareApiAspNetCore.Communication.Requests;
public class RequestStockJson
{
    public string Nome_Produto { get; set; } = string.Empty;
    public string Categoria_Produto { get; set; } = string.Empty;
    public int Quantidade_Estoque { get; set; }
    public DateTime Data_Validade { get; set; }
    public DateTime Data_Entrada_Estoque { get; set; }
    public string Localizacao_Estoque { get; set; } = string.Empty;
    public string Fornecedor { get; set; } = string.Empty;
    public decimal Preco_Unitario { get; set; }
    public string Unidade_Medida { get; set; } = string.Empty;
}
