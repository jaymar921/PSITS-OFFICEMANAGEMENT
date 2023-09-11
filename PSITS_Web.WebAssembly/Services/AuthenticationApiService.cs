using System.Net;
using System.Text;

namespace PSITS_Web.WebAssembly.Services
{
    public class AuthenticationApiService
    {
        private readonly HttpClient httpClient;

        public AuthenticationApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Authenticate()
        {
            var cookies = new CookieContainer();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "auth/login/rfid");
            var content = new StringContent("{\"rfid\":\"3319695443\"}", Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("auth/login/rfid", content);

            Uri uri = new Uri(httpClient.BaseAddress?.ToString());
            IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast < Cookie > ();

            foreach(Cookie cookie in responseCookies)
            {
                Console.WriteLine(cookie.Name + ": " + cookie.Value);
            }
        }
    }
}
