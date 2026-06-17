using System.ComponentModel.DataAnnotations;
using ProjetoNsaSenhora.Enums;

namespace ProjetoNsaSenhora.DTOs;

public class UpdateProdutoDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
    [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(300, ErrorMessage = "A descrição deve ter no máximo 300 caracteres.")]
    [MinLength(5, ErrorMessage = "A descrição deve ter pelo menos 5 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Range(0, int.MaxValue,
        ErrorMessage = "A quantidade em estoque não pode ser negativa.")]
    public int QuantidadeEstoque { get; set; }

    [Required]
    [Range(0.01, double.MaxValue,
        ErrorMessage = "O preço unitário deve ser maior que zero.")]
    public decimal PrecoUnitario { get; set; }

    [Range(0, 1)]
    public double PercentualDesconto { get; set; }

    [EnumDataType(typeof(StatusCategoria))]
    public StatusCategoria StatusCategoria { get; set; }
}