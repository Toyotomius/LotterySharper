using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LotterySharperBlazorServer
{
    /// <summary>
    /// API request service for Lotto 649
    /// </summary>
    public class PowerBallService
    {/// <summary>
     /// Constructor for L649 API requests
     /// </summary>
     /// <param name="client">Http Client injected via DI</param>
        public PowerBallService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44381");

            Client = client;
        }

        public HttpClient Client { get; }

        /// <summary>
        /// Get request for main PowerBall results.
        /// </summary>
        /// <returns>returns Json string from API</returns>
        public async Task<string> GetPowerBallAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/PowerBall/");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }

        public async Task<string> GetPowerBallBonusAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/PowerBall/bonus");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }

        public async Task<string> GetPowerBallPairsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/PowerBall/pairs");

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
        public async Task<string> GetPowerBallSinglesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/PowerBall/singles");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }

        public async Task<string> GetPowerBallTripletsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/api/PowerBall/triplets");

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else { return null; }
        }
    }
}
