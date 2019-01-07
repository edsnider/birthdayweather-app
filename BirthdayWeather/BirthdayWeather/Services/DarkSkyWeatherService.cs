using System;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using BirthdayWeather.Services;
using BirthdayWeather.Services.ApiResponseModels.DarkSky;
using BirthdayWeather.Models;

[assembly: Dependency(typeof(DarkSkyWeatherService))]
namespace BirthdayWeather.Services
{
    public class DarkSkyWeatherService : IWeatherService
    {
        readonly HttpClient _client;
        const string _key = "";

        public DarkSkyWeatherService()
        {
            _client = new HttpClient();
        }

        public async Task<Forecast> GetWeatherAsync(double latitude, double longitude)
        {
            return await GetWeatherAsync(latitude, longitude, null);
        }

        public async Task<Forecast> GetWeatherAsync(double latitude, double longitude, DateTime? date)
        {
            var url = $"https://api.darksky.net/forecast/{_key}/{latitude},{longitude}";

            if (date.HasValue)
            {
                var unixTime = date.Value.ToEpochTime();
                url += $",{unixTime}";
            }

            var content = await _client.GetStringAsync(url);

            return DarkSkyResponse.FromJson(content)
                                  .ToForecastModel();
        }
    }
}
