using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoNsaSenhora.Data;
using ProjetoNsaSenhora.Models;

namespace ProjetoNsaSenhora.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        // Injeção de dependência do AppDbContext para acesso ao banco de dados
        private readonly AppDbContext _appDbContext;
        public ProdutosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // POST api/produtos
        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduto(Produto produto)
        {
            produto.Id = Guid.NewGuid();
            produto.DataCadastro = DateTime.UtcNow;
            produto.Ativo = true;
            produto.ValorTotalEstoque = produto.QuantidadeEstoque * produto.PrecoUnitario;

            await _appDbContext.Produtos.AddAsync(produto);
            await _appDbContext.SaveChangesAsync();
            
            return CreatedAtAction(
                nameof(GetProduto), 
                new { id = produto.Id }, 
                produto);
        }

        // GET GetAll - Produtos marcados como Ativo = true.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProdutos()
        {
            var produtos = await _appDbContext.Produtos
                .AsNoTracking()
                .Where(p => p.Ativo)
                .ToListAsync();

            return Ok(produtos);
        }

        // GET GetId - Pesquisa por ID.
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduto(Guid id)
        {
            var produto = await _appDbContext.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }


        // GET Get Descrição - Filtra registros na base pela 'Descricao'.
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchProdutos(string descricao)
        {
            var produtos = await _appDbContext.Produtos
                .AsNoTracking()
                .Where(p => p.Descricao.Contains(descricao))
                .ToListAsync();

            return Ok(produtos);
        }

        // PUT - Modifica as propriedades permitidas pelo Id, recalculando o valor total de estoque antes de atualizar o banco.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduto(Guid id, Produto updatedProduto)
        {
            var produto = await _appDbContext.Produtos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            produto.Nome = updatedProduto.Nome;
            produto.Descricao = updatedProduto.Descricao;
            produto.QuantidadeEstoque = updatedProduto.QuantidadeEstoque;
            produto.PrecoUnitario = updatedProduto.PrecoUnitario;
            produto.PercentualDesconto = updatedProduto.PercentualDesconto;
            produto.StatusCategoria = updatedProduto.StatusCategoria;
            produto.ValorTotalEstoque = updatedProduto.ValorTotalEstoque;

            await _appDbContext.SaveChangesAsync();
            
            return NoContent();
        }

        // DELETE - Soft Delete. Marca o produto como Inativo (Ativo = false) sem remover fisicamente o registro do banco de dados.
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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