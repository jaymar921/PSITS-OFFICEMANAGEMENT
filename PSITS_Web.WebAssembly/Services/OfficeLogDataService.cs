using Microsoft.JSInterop;
using PSITS_Web.Common;

namespace PSITS_Web.WebAssembly.Services
{
    public class OfficeLogDataService : IOfficeLogDataService
    {
        private readonly IJSRuntime JSRuntime;
        public OfficeLogDataService(IJSRuntime JSRuntime)
        {
            this.JSRuntime = JSRuntime;
        }

        public async Task<int> CloseOfficeLog()
        {
            return await JSRuntime.InvokeAsync<int>("PSITS_API_OfficeLogOff");
        }

        public async Task<OfficeLogs> GetAllOfficeLogs(string option = "", DateTime min = default, DateTime max = default)
        {
            var data = await JSRuntime.InvokeAsync<OfficeLogs>("PSITS_API_GetAllOfficeLogs", option, min, max);
            return data ?? new();
        }

        public async Task<int> OpenOfficeLogs(string reason)
        {
            return await JSRuntime.InvokeAsync<int>("PSITS_API_OfficeLogIn", reason);
        }
    }
}
