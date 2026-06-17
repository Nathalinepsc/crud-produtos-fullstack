using ProjetoNsaSenhora.Models;

namespace ProjetoNsaSenhora.Repositories.Interfaces;

public interface IProdutoRepository
{
    Task<List<Produto>> GetAllAsync();

    Task<Produto?> GetByIdAsync(Guid id);

    Task<List<Produto>> SearchByDescricaoAsync(string descricao);

    Task AddAsync(Produto produto);

    Task SaveChangesAsync();
    Task<Produto?> GetByIdForUpdateAsync(Guid id);
}