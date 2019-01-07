using System;
using System.Threading.Tasks;
using BirthdayWeather.Models;

namespace BirthdayWeather.Services
{
    public interface IWeatherService
    {
        Task<Forecast> GetWeatherAsync(double latitude, double longitude);
        Task<Forecast> GetWeatherAsync(double latitude, double longitude, DateTime? date);
    }
}
