using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShopService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductDTO>> GetAll() => await _httpClient.GetFromJsonAsync<IEnumerable<ProductDTO>>("Product");
        public async Task<ProductDTO> GetById(int id) => await _httpClient.GetFromJsonAsync<ProductDTO>($"Product({id})");
        public async Task Create(ProductDTO product) => await _httpClient.PostAsJsonAsync("Product", product);
        public async Task Update(ProductDTO product) => await _httpClient.PutAsJsonAsync($"Product({product.ProductId})", product);
        public async Task Delete(int id) => await _httpClient.DeleteAsync($"Product({id})");
    }
}