using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LotterySharperBlazorServer
{
    /// <summary>
    /// API request service for Lotto 649
    /// </summary>
    public class Lotto649Service
    {/// <summary>
     /// Constructor for L649 API requests
     /// </summary>
     /// <param name="client">Http Client injected via DI</param>
        public Lotto649Service(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44381");

            Client = client;
        }

        public HttpClient Client { get; }

        /// <summary>
        /// Get request for main L649 results.
        /// </summary>
        /// <returns>returns Json string from API</returns>
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

        public async Task<string> GetLotto649BonusAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/lotto649/bonus");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }

        public async Task<string> GetLotto649PairsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/lotto649/pairs");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }

        /// <summary>
        /// Get request for L649 Singles Frequency
        /// </summary>
        /// <returns>Returns Json string from API containing a list of First and Frequency key/value pairs</returns>
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

        public async Task<string> GetLotto649TripletsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/lotto649/triplets");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }
    }
}
