using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GscareApiAspNetCore.Domain.Entities;
public class Stock
{
    public long Id { get; set; }
    public string Nome_Produto { get; set; } = string.Empty;
    public string Categoria_Produto { get; set; } = string.Empty;
    public int Quantidade_Estoque { get; set; }
    public DateTime Data_Validade { get; set; }
    public DateTime Data_Entrada_Estoque { get; set; }
    public string Localizacao_Estoque { get; set; } = string.Empty;
    public string Fornecedor { get; set; } = string.Empty;
    public decimal Preco_Unitario { get; set; }
    public string Unidade_Medida { get; set; } = string.Empty;
    public long CompanyId { get; set; } // chave estrangeira

    public Company Company { get; set; } = null!;// propriedade de navegação para a empresa
}