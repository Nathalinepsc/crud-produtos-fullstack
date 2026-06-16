using System.ComponentModel.DataAnnotations;
using ProjetoNsaSenhora.Enums;

namespace ProjetoNsaSenhora.Models
{
    public class Produto
    {
        // Propriedade para controle de ID do produto
        public Guid Id { get; set; }

        // Propriedade para controle de nome do produto com validação de requisitos de comprimento e obrigatoriedade
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        // Propriedade para controle de descrição do produto
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        // Propriedade para controle de quantidade em estoque sem aceitar valores negativos
        [Range(0, int.MaxValue,
            ErrorMessage = "A quantidade em estoque não pode ser negativa.")]
        public int QuantidadeEstoque { get; set; }

        // Propriedade para controle de preço unitário sem aceitar valores negativos ou zero
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço unitário deve ser maior que zero.")]
        public decimal PrecoUnitario { get; set; }

        // Propriedade para controle de data de cadastro
        public DateTime DataCadastro { get; set; }

        // Propriedade para controle de desconto
        [Range(0, 1)]
        public decimal PercentualDesconto { get; set; }

        // Propriedade para controle de categoria do produto com validação de enumeração
        [EnumDataType(typeof(StatusCategoria))]
        public Enums.StatusCategoria StatusCategoria { get; set; }

        // Propriedade para controle de ativação do produto
        public bool Ativo { get; set; }

        // Propriedade calculada para o valor total em estoque
        public decimal ValorTotalEstoque { get; set; }
    }
}