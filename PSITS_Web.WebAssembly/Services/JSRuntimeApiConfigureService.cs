using Microsoft.JSInterop;

namespace PSITS_Web.WebAssembly.Services
{
    public class JSRuntimeApiConfigureService
    {
        private readonly HttpClient HttpClient;
        private readonly IJSRuntime JSRuntime;

        public JSRuntimeApiConfigureService(HttpClient httpClient, IJSRuntime jSRuntime)
        {
            HttpClient = httpClient;
            JSRuntime = jSRuntime;
        }

        public async Task LoadJSConfig()
        {
            Console.WriteLine("Loaded JS Config");
            await JSRuntime.InvokeVoidAsync("SetApiGlobals", HttpClient.BaseAddress?.ToString());
        }
    }
}
