using ProjetoNsaSenhora.DTOs;
using ProjetoNsaSenhora.Models;

namespace ProjetoNsaSenhora.Services.Interfaces;

public interface IProdutoService
{
    Task<Produto> CreateAsync(CreateProdutoDto dto);

    Task<List<Produto>> GetAllAsync();

    Task<Produto?> GetByIdAsync(Guid id);

    Task<List<Produto>> SearchByDescricaoAsync(string descricao);

    Task<bool> UpdateAsync(Guid id, UpdateProdutoDto dto);

    Task<bool> SoftDeleteAsync(Guid id);
}