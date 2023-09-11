using PSITS_Web.Common;
using System.Globalization;
using System.Text.Json;

namespace PSITS_Web.WebAssembly.Services
{
    public class OfficeLogDataService : IOfficeLogDataService
    {
        private readonly HttpClient _httpClient;

        public OfficeLogDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task CloseOfficeLog(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OfficeLog>> GetAllOfficeLogs(DateTime min = default, DateTime max = default)
        {
            _httpClient.DefaultRequestHeaders.Add("min", min.ToString("o", CultureInfo.InvariantCulture));
            _httpClient.DefaultRequestHeaders.Add("max", max.ToString("o", CultureInfo.InvariantCulture));
            
            var data = await JsonSerializer.DeserializeAsync<IEnumerable<OfficeLog>>(await _httpClient.GetStreamAsync($"officelog"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return data ?? new List<OfficeLog> { };
        }

        public Task OpenOfficeLogs(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
