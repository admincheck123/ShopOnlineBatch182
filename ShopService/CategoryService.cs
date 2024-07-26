using ShopDTO;
using System.Net.Http.Json;

namespace ShopService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAll() => await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDTO>>("Category");
        public async Task<CategoryDTO> GetById(int id) => await _httpClient.GetFromJsonAsync<CategoryDTO>($"Category({id})");
        public async Task Create(CategoryDTO category) => await _httpClient.PostAsJsonAsync("Category", category);
        public async Task Update(CategoryDTO category) => await _httpClient.PutAsJsonAsync($"Category({category.CategoryId})", category);
        public async Task Delete(int id) => await _httpClient.DeleteAsync($"Category({id})");
    }
}