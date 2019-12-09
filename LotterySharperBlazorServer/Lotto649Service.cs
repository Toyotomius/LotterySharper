using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LotterySharperBlazorServer
{
    public class Lotto649Service
    {
        public Lotto649Service(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44381");

            Client = client;
        }

        public HttpClient Client { get; }

        public async Task<string> GetLotto649Async()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/lotto649/");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }

        public async Task<string> GetLotto649SinglesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/lotto649/singles");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }
    }
}
