using ProjetoNsaSenhora.DTOs;
using ProjetoNsaSenhora.Models;
using ProjetoNsaSenhora.Repositories.Interfaces;
using ProjetoNsaSenhora.Services.Interfaces;

namespace ProjetoNsaSenhora.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> CreateAsync(CreateProdutoDto dto)
        {
            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                QuantidadeEstoque = dto.QuantidadeEstoque,
                PrecoUnitario = dto.PrecoUnitario,
                PercentualDesconto = dto.PercentualDesconto,
                StatusCategoria = dto.StatusCategoria,

                DataCadastro = DateTime.UtcNow,
                Ativo = true,

                ValorTotalEstoque =
                    dto.QuantidadeEstoque * dto.PrecoUnitario
            };

            await _produtoRepository.AddAsync(produto);
            await _produtoRepository.SaveChangesAsync();

            return produto;
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<Produto?> GetByIdAsync(Guid id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<List<Produto>> SearchByDescricaoAsync(string descricao)
        {
            return await _produtoRepository.SearchByDescricaoAsync(descricao);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateProdutoDto dto)
        {
            var produto =
                await _produtoRepository.GetByIdForUpdateAsync(id);

            if (produto == null)
            {
                return false;
            }

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.QuantidadeEstoque = dto.QuantidadeEstoque;
            produto.PrecoUnitario = dto.PrecoUnitario;
            produto.PercentualDesconto = dto.PercentualDesconto;
            produto.StatusCategoria = dto.StatusCategoria;

            produto.ValorTotalEstoque =
                dto.QuantidadeEstoque * dto.PrecoUnitario;

            await _produtoRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SoftDeleteAsync(Guid id)
        {
            var produto =
                await _produtoRepository.GetByIdForUpdateAsync(id);

            if (produto == null)
            {
                return false;
            }

            produto.Ativo = false;

            await _produtoRepository.SaveChangesAsync();

            return true;
        }
    }
}