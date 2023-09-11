using Microsoft.AspNetCore.Components;
using PSITS_Web.Common;
using PSITS_Web.WebAssembly.Services;

namespace PSITS_Web.WebAssembly.Pages
{
    public partial class Index
    {

        [Inject]
        public IOfficeLogDataService? DataService { get; set; }
        [Inject]
        public AuthenticationApiService AuthenticationApiService { get; set; }

        public IEnumerable<OfficeLog> officeLogs { get; set; } = Enumerable.Empty<OfficeLog>();

        protected override async Task OnInitializedAsync()
        {
            await AuthenticationApiService.Authenticate();
            officeLogs = (await DataService.GetAllOfficeLogs(max: DateTime.UtcNow)).ToList();
        }
    }
}
