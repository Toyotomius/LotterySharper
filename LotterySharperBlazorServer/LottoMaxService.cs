using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LotterySharperBlazorServer
{
    /// <summary>
    /// API request service for Lotto 649
    /// </summary>
    public class LottoMaxService
    {/// <summary>
     /// Constructor for L649 API requests
     /// </summary>
     /// <param name="client">Http Client injected via DI</param>
        public LottoMaxService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44381");

            Client = client;
        }

        public HttpClient Client { get; }

        /// <summary>
        /// Get request for main LottoMax results.
        /// </summary>
        /// <returns>returns Json string from API</returns>
        public async Task<string> GetLottoMaxAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/LottoMax/");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }

        public async Task<string> GetLottoMaxBonusAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/LottoMax/bonus");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }

        public async Task<string> GetLottoMaxPairsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/LottoMax/pairs");

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
        public async Task<string> GetLottoMaxSinglesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/LottoMax/singles");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }

        public async Task<string> GetLottoMaxTripletsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/LottoMax/triplets");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }
    }
}
