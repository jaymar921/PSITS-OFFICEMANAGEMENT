using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using PSITS_Web.WebAssembly;
using PSITS_Web.WebAssembly.Classes;
using PSITS_Web.WebAssembly.Handler;
using PSITS_Web.WebAssembly.Services;

namespace PSITS_Web.WebAssembly
{
    public class Program
    {
        private static string localApiUrl = "http://localhost:3000/api/v2/";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Register the Data Services
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API:URL"] ?? localApiUrl) });

            builder.Services.AddScoped<IOfficeLogDataService, OfficeLogDataService>();
            builder.Services.AddScoped<AuthenticationApiService>();
            builder.Services.AddScoped<JSRuntimeApiConfigureService>();

            var app = builder.Build();

            // Load the JS Configuration for the API Secrets
            using(var scope = app.Services.CreateScope())
            {
                var apiService = scope.ServiceProvider.GetService<JSRuntimeApiConfigureService>();
                if(null != apiService)
                    _ = apiService.LoadJSConfig();
            }

            await app.RunAsync();
        }
    }
}