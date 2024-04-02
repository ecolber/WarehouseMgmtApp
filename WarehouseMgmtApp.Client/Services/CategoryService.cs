using System.Net.Http.Json;
using WarehouseMgmtApp.Client.Services.Dtos;

namespace WarehouseMgmtApp.Client.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>("Category");


                return result!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int Id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<CategoryDto>("Category/" + Id);


                return result!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task AddCategoryAsync(CategoryDto category)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Category", category);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task UpdateCategory(CategoryDto category, int id)
        {
            var response = await _httpClient.PutAsJsonAsync("Category/" + id, category);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var response = await _httpClient.DeleteAsync("Category/" + Id);
            return response.IsSuccessStatusCode;
        }

    }
}
