using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> AddProduto(Produto produto)
        {
            produto.Id = Guid.NewGuid();
            produto.DataCadastro = DateTime.UtcNow;

            _appDbContext.Produtos.Add(produto);
            await _appDbContext.SaveChangesAsync();

            return Ok (produto);
        }
    }
}