using System.Net.Http.Json;
using WarehouseMgmtApp.Client.Services.Dtos;

namespace WarehouseMgmtApp.Client.Services
{
    public class ProductTypeService
    {
        private readonly HttpClient _httpClient;

        public ProductTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductTypeDto>> GetProductTypeAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<ProductTypeDto>>("ProductType");


                return result!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ProductTypeDto> GetProductTypeByIdAsync(int Id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ProductTypeDto>("ProductType/" + Id);


                return result!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task AddProductTypeAsync(ProductTypeDto productType)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("ProductType", productType);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task UpdateProductTypeAsync(ProductTypeDto productType, int id)
        {
            var response = await _httpClient.PutAsJsonAsync("ProductType/" + id, productType);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteProductTypeAsync(int Id)
        {
            var response = await _httpClient.DeleteAsync("ProductType/" + Id);
            return response.IsSuccessStatusCode;
        }
    }
}
