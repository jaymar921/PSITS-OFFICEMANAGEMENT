using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PSITS_Web.WebAssembly;
using PSITS_Web.WebAssembly.Handler;
using PSITS_Web.WebAssembly.Services;

namespace PSITS_Web.WebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            // Register the Data Services

            builder.Services.AddScoped(sp => new HttpClient(new CookieHandler()) { BaseAddress = new Uri(builder.Configuration["API:URL"] ?? "http://localhost:3000/api/v2/") });
            builder.Services.AddHttpClient<IOfficeLogDataService, OfficeLogDataService>(client => client.BaseAddress = new Uri(builder.Configuration["API:URL"]??"http://localhost:3000/api/v2/"));
            builder.Services.AddHttpClient<AuthenticationApiService, AuthenticationApiService>(client => client.BaseAddress = new Uri(builder.Configuration["API:URL"] ?? "http://localhost:3000/api/v2/"));

            await builder.Build().RunAsync();
        }
    }
}