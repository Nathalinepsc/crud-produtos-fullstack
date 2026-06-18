using Microsoft.AspNetCore.Mvc;
using ProjetoNsaSenhora.Web.Models;

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

    public IActionResult Create()
    {
        return View();
    }

   [HttpPost]
    public async Task<IActionResult> Create(ProdutoCreateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _produtoApiService.CriarAsync(model);

        return RedirectToAction(nameof(Index));
    }

}