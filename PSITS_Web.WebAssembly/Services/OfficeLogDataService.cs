using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using PSITS_Web.Common;
using PSITS_Web.WebAssembly.Classes;
using System.Globalization;
using System.Text.Json;

namespace PSITS_Web.WebAssembly.Services
{
    public class OfficeLogDataService : IOfficeLogDataService
    {
        private readonly IJSRuntime JSRuntime;
        public OfficeLogDataService(IJSRuntime JSRuntime)
        {
            this.JSRuntime = JSRuntime;
        }

        public Task CloseOfficeLog(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OfficeLog>> GetAllOfficeLogs(DateTime min = default, DateTime max = default)
        {
            throw new NotImplementedException();
        }

        public Task OpenOfficeLogs(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
