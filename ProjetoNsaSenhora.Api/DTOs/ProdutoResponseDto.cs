using ProjetoNsaSenhora.Enums;

namespace ProjetoNsaSenhora.DTOs;

public class ProdutoResponseDto
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public int QuantidadeEstoque { get; set; }

    public decimal PrecoUnitario { get; set; }

    public decimal ValorTotalEstoque { get; set; }

    public DateTime DataCadastro { get; set; }

    public double PercentualDesconto { get; set; }

    public StatusCategoria StatusCategoria { get; set; }

    public bool Ativo { get; set; }
}