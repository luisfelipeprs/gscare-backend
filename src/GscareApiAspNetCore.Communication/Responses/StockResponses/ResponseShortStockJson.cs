namespace GscareApiAspNetCore.Communication.Responses.StockResponses;
public class ResponseShortStockJson
{
    public long Id { get; set; }
    public string Nome_Produto { get; set; } = string.Empty;
    public int Quantidade_Estoque { get; set; }
}
