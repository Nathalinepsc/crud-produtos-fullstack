namespace ProjetoNsaSenhora.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal PercentualDesconto { get; set; }
        public Enums.StatusCategoria StatusCategoria { get; set; }
        public bool Ativo { get; set; }
        public decimal ValorTotalEstoque =>
            QuantidadeEstoque * PrecoUnitario;
    }
}