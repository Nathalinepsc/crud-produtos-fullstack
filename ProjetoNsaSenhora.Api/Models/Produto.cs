using System.ComponentModel.DataAnnotations;
using ProjetoNsaSenhora.Enums;
namespace ProjetoNsaSenhora.Models
{
    public class Produto
    {
        // ID do produto, gerado automaticamente
        public Guid Id { get; set; }

        // Nome do produto, obrigatório, mínimo de 3 caracteres e máximo de 150 caracteres
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        // Descrição do produto, obrigatória
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(300, ErrorMessage = "A descrição deve ter no máximo 300 caracteres.")]
        [MinLength(5, ErrorMessage = "A descrição deve ter pelo menos 5 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        // Quantidade em estoque, não pode ser negativa
        [Range(0, int.MaxValue,
            ErrorMessage = "A quantidade em estoque não pode ser negativa.")]
        public int QuantidadeEstoque { get; set; }

        // Preço unitário do produto, obrigatório e deve ser maior que zero
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço unitário deve ser maior que zero.")]
        public decimal PrecoUnitario { get; set; }
        
        // Valor total em estoque, calculado na entidade
        public decimal ValorTotalEstoque { get; set; }

        // Data de cadastro do produto, gerada automaticamente
        public DateTime DataCadastro { get; set; }

        // Percentual de desconto do produto, deve estar entre 0 e 1. Ex.: 0.15 = 15%
        [Range(0, 1)]
        public double PercentualDesconto { get; set; }

        // Status da categoria do produto Enum com validação para garantir que o valor seja um dos definidos no enum
        [EnumDataType(typeof(StatusCategoria))]
        public StatusCategoria StatusCategoria { get; set; }

        // Indica se o produto está ativo ou inativo
        public bool Ativo { get; set; }

    }
}