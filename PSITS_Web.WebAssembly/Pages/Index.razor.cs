using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

    }
}
