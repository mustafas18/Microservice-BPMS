using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BpmsApi.Services
{
    public class VariablesService
    {
        private readonly HttpClient _httpClient;

        public VariablesService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("VariablesApi");
        }

        public async Task<string?> GetVariableAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(content);
            return doc.RootElement.GetProperty("Name").GetString();
        }
    }
}
