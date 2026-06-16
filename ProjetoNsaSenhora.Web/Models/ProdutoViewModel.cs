namespace ProjetoNsaSenhora.Web.Models;

public class ProdutoViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public int QuantidadeEstoque { get; set; }

    public decimal PrecoUnitario { get; set; }

    public DateTime DataCadastro { get; set; }

    public decimal PercentualDesconto { get; set; }

    public int StatusCategoria { get; set; }

    public bool Ativo { get; set; }

    public decimal ValorTotalEstoque { get; set; }
}