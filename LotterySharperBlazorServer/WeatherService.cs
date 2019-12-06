using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LotterySharperBlazorServer.Data;

namespace LotterySharperBlazorServer
{
    public class WeatherService
    {
        public HttpClient Client { get; }


        public WeatherService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44381");

            Client = client;
        }

        public async Task<WeatherForecast[]> GetWeatherAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://localhost:44381/weatherforecast");



            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<WeatherForecast[]>(responseStream));

            }
            else { return null; }

            // Could still deserialize on razor page using return await response.Content.ReadAsStringAsync
        }


    }

}

