using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoNsaSenhora.Data;
using ProjetoNsaSenhora.Models;

namespace ProjetoNsaSenhora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ProdutosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // POST api/produtos
        [HttpPost]
        public async Task<IActionResult> CreateProduto(Produto produto)
        {
            produto.Id = Guid.NewGuid();
            produto.DataCadastro = DateTime.UtcNow;
            produto.Ativo = true;

            await _appDbContext.Produtos.AddAsync(produto);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        // GET GetAll - Produtos marcados como Ativo = true.
        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            var produtos = await _appDbContext.Produtos.Where(p => p.Ativo).ToListAsync();
            return Ok(produtos);
        }



        // GET GetId - Pesquisa por ID Ativo = true.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(Guid id)
        {
            var produto = await _appDbContext.Produtos
                .FirstOrDefaultAsync(p => p.Id == id && p.Ativo);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }


        // GET Get Descrição - Filtra registros na base pela 'Descricao'.
        [HttpGet("search")]
        public async Task<IActionResult> SearchProdutos(string descricao)
        {
            var produtos = await _appDbContext.Produtos
                .Where(p => p.Descricao.Contains(descricao) && p.Ativo)
                .ToListAsync();
            return Ok(produtos);
        }

        // PUT - Modifica as propriedades permitidas pelo Id, recalculando o valor total de estoque antes de atualizar o banco.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(Guid id, Produto updatedProduto)
        {
            var produto = await _appDbContext.Produtos
                .FirstOrDefaultAsync(p => p.Id == id && p.Ativo);
            if (produto == null)
            {
                return NotFound();
            }

            // Atualiza as propriedades permitidas
            produto.Nome = updatedProduto.Nome;
            produto.Descricao = updatedProduto.Descricao;
            produto.QuantidadeEstoque = updatedProduto.QuantidadeEstoque;
            produto.PrecoUnitario = updatedProduto.PrecoUnitario;
            produto.PercentualDesconto = updatedProduto.PercentualDesconto;
            produto.StatusCategoria = updatedProduto.StatusCategoria;

            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE - Soft Delete. Marca o produto como Inativo (Ativo = false) sem remover fisicamente o registro do banco de dados.
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteProduto(Guid id)
        {
            var produto = await _appDbContext.Produtos
                .FirstOrDefaultAsync(p => p.Id == id && p.Ativo);

            if (produto == null)
            {
                return NotFound();
            }

            produto.Ativo = false;

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}