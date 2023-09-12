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
            /*
            var content = new StringContent("{\"rfid\":\"3319695443\"}", Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("auth/login/rfid", content);
            response.EnsureSuccessStatusCode();

            var serializedAuth = JsonSerializer.DeserializeAsync<Authentication>(await response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Authentication auth = serializedAuth.Result ?? new();

            //await _cookie.SetValue("token", auth.Token);
            */
            
            await JSRuntime.InvokeVoidAsync("PSITS_API_Authenticate", rfid, password);
        }
    }
}
