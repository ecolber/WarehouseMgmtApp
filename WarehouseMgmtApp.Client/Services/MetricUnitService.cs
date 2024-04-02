using System.Net.Http.Json;
using WarehouseMgmtApp.Client.Services.Dtos;

namespace WarehouseMgmtApp.Client.Services
{
    public class MetricUnitService
    {
        private readonly HttpClient _httpClient;

        public MetricUnitService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MetricUnitDto>> GetMetricUnitAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<IEnumerable<MetricUnitDto>>("MetricUnit");


                return result!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<MetricUnitDto> GetMetricUnitByIdAsync(int Id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<MetricUnitDto>("MetricUnit/" + Id);


                return result!;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task AddMetricUnitAsync(MetricUnitDto metricUnit)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("MetricUnit", metricUnit);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task UpdateMetricUnitAsync(MetricUnitDto metricUnit, int id)
        {
            var response = await _httpClient.PutAsJsonAsync("MetricUnit/" + id, metricUnit);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteMetricUnitAsync(int Id)
        {
            var response = await _httpClient.DeleteAsync("MetricUnit/" + Id);
            return response.IsSuccessStatusCode;
        }
    }
}
