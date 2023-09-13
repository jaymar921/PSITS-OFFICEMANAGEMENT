using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PSITS_Web.Common.Auth;
using PSITS_Web.WebAssembly.Classes;
using System.Net;
using System.Text;
using System.Text.Json;

namespace PSITS_Web.WebAssembly.Services
{
    public class AuthenticationApiService
    {
        private readonly IJSRuntime JSRuntime;

        public AuthenticationApiService(IJSRuntime jSRuntime)
        {
            this.JSRuntime = jSRuntime;
        }

        public async Task Authenticate(string rfid, string? password = null)
        {   
            await JSRuntime.InvokeVoidAsync("PSITS_API_Authenticate", rfid, password);
        }
    }
}
