namespace ProjetoNsaSenhora.Web.Models;

public class ProdutoCreateViewModel
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int QuantidadeEstoque { get; set; }
    public decimal PrecoUnitario { get; set; }
    public double PercentualDesconto { get; set; }
    public int StatusCategoria { get; set; }
}