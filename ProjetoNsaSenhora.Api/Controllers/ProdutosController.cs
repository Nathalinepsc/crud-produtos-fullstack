using Microsoft.AspNetCore.Mvc;
using ProjetoNsaSenhora.DTOs;
using ProjetoNsaSenhora.Services.Interfaces;
using ProjetoNsaSenhora.Models;

namespace ProjetoNsaSenhora.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
       // Injeção de dependência do serviço de produtos
       private readonly IProdutoService _produtoService;

       public ProdutosController(IProdutoService produtoService)
       {
           _produtoService = produtoService;
       }

        // POST Create - Cria um novo produto, calculando o valor total de estoque com base na quantidade e preço unitário.
        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduto(CreateProdutoDto dto)
        {
            var produto = await _produtoService.CreateAsync(dto);

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
            var produtos = await _produtoService.GetAllAsync();

            return Ok(produtos);
        }

        // GET GetId - Pesquisa por ID.
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduto(Guid id)
        {
            var produto = await _produtoService.GetByIdAsync(id);

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
            var produtos = await _produtoService.SearchByDescricaoAsync(descricao);

            return Ok(produtos);
        }

        // PUT - Modifica as propriedades permitidas pelo Id, recalculando o valor total de estoque antes de atualizar o banco.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduto(Guid id, UpdateProdutoDto dto)
        {
            var atualizado = await _produtoService.UpdateAsync(id, dto);

            if (!atualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE - Soft Delete. Marca o produto como Inativo (Ativo = false) em vez de removê-lo fisicamente do banco de dados.
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProduto(Guid id)
        {
            var removido =
                await _produtoService.SoftDeleteAsync(id);

            if (!removido)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}