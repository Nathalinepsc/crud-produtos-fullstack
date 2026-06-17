using Microsoft.EntityFrameworkCore;
using ProjetoNsaSenhora.Data;
using ProjetoNsaSenhora.Models;
using ProjetoNsaSenhora.Repositories.Interfaces;

namespace ProjetoNsaSenhora.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await _appDbContext.Produtos
                .AsNoTracking()
                .Where(p => p.Ativo)
                .ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Produto>> SearchByDescricaoAsync(string descricao)
        {
            return await _appDbContext.Produtos
                .AsNoTracking()
                .Where(p => p.Descricao.Contains(descricao))
                .ToListAsync();
        }

        public async Task AddAsync(Produto produto)
        {
            await _appDbContext.Produtos.AddAsync(produto);
        }

        public Task SaveChangesAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }
        public async Task<Produto?> GetByIdForUpdateAsync(Guid id)
        {
            return await _appDbContext.Produtos
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}