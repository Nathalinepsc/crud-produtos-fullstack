namespace ProjetoNsaSenhora.Models
{
    public class Produto
    {
        // Propriedade para controle de ID do produto
        public Guid Id { get; set; }

        // Propriedade para controle de nome do produto
        public string Nome { get; set; }

        // Propriedade para controle de descrição do produto
        public string Descricao { get; set; }

        // Propriedade para controle de quantidade em estoque
        public int QuantidadeEstoque { get; set; }

        // Propriedade para controle de preço unitário
        public decimal PrecoUnitario { get; set; }

        // Propriedade para controle de data de cadastro
        public DateTime DataCadastro { get; set; }

        // Propriedade para controle de desconto
        public decimal PercentualDesconto { get; set; }

        // Propriedade para controle de categoria do produto
        public Enums.StatusCategoria StatusCategoria { get; set; }

        // Propriedade para controle de ativação do produto
        public bool Ativo { get; set; }

        // Propriedade calculada para o valor total em estoque
        public decimal ValorTotalEstoque => QuantidadeEstoque * PrecoUnitario;

        // Propriedade para controle de exclusão lógica
        public bool IsDeleted { get; set; }
    }
}