using Microsoft.AspNetCore.Mvc;

public class ProdutosController : Controller
{
    private readonly ProdutoApiService _produtoApiService;

    public ProdutosController(ProdutoApiService produtoApiService)
    {
        _produtoApiService = produtoApiService;
    }

    public async Task<IActionResult> Index()
    {
        var produtos = await _produtoApiService.ObterTodosAsync();
        return View(produtos);
    }
}