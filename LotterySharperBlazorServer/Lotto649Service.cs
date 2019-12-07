using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LotterySharperBlazorServer
{
    public class Lotto649Service
    {
        public HttpClient Client { get; }

        public Lotto649Service(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44381");

            Client = client;
        }

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
    }
}
