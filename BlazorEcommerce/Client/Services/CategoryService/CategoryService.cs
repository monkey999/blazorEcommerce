using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public List<Category> Categories { get; set; } = new List<Category>();

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetCategoriesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");

            if (result != null && result.Data != null)
            {
                Categories = result.Data;
            }
        }
    }
}
