using Microsoft.AspNetCore.Mvc;
using ProjetoNsaSenhora.Web.Models;

namespace ProjetoNsaSenhora.Web.Controllers;

public class ProdutosController : Controller
{
    private readonly HttpClient _httpClient;

    public ProdutosController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiProdutos");
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("api/produtos");

        if (!response.IsSuccessStatusCode)
        {
            return View(new List<ProdutoViewModel>());
        }

        var produtos = await response.Content
            .ReadFromJsonAsync<List<ProdutoViewModel>>();

        return View(produtos ?? new List<ProdutoViewModel>());
    }
}