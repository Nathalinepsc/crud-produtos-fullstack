using ProjetoNsaSenhora.Web.Models;

public class ProdutoApiService
{
    private readonly HttpClient _httpClient;

    public ProdutoApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiProdutos");
    }

    public async Task<List<ProdutoViewModel>> ObterTodosAsync()
    {
        var response = await _httpClient.GetAsync("api/produtos");

        if (!response.IsSuccessStatusCode)
        {
            return new List<ProdutoViewModel>();
        }

        var produtos = await response.Content
            .ReadFromJsonAsync<List<ProdutoViewModel>>();

        return produtos ?? new List<ProdutoViewModel>();
    }

    public async Task CriarAsync(ProdutoCreateViewModel produto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/produtos", produto);

        response.EnsureSuccessStatusCode();
    }

    internal async Task CriarAsync(ProdutoViewModel produto)
    {
        throw new NotImplementedException();
    }
}

