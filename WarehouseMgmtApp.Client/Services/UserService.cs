
using System.Net.Http.Json;
using WarehouseMgmtApp.Client.Services.Dtos;

namespace WarehouseMgmtApp.Client.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> LoginAsync(UserDto user)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("Login", user);
                result.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta no es exitosa
                

                // Si la respuesta es exitosa, asumimos que el inicio de sesión fue exitoso
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

      
    }
}
