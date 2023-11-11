namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public event Action ProductsChanged;

        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProductsAsync(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");

            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }

            ProductsChanged.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");

            return result;
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _httpClient
                .GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");

            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }

            if (Products.Count == 0)
            {
                Message = "No products found.";
            }

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient
                .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");

            return result.Data;
        }
    }
}
