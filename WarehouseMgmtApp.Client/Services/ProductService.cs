using System.Net.Http.Json;
using WarehouseMgmtApp.Client.Services.Dtos;

namespace WarehouseMgmtApp.Client.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("Product");

                return result!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ProductDto> GetProductByIdAsync(int Id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ProductDto>("Product/" + Id);


                return result!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task AddProductAsync(ProductDto product)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Product", product);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task UpdateProductAsync(ProductDto product, int id)
        {
            var response = await _httpClient.PutAsJsonAsync("Product/" + id, product);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteProductAsync(int Id)
        {
            var response = await _httpClient.DeleteAsync("Product/" + Id);
            return response.IsSuccessStatusCode;
        }
    }
}
