using System;
using System.Threading.Tasks;

namespace BirthdayWeather.Services
{
    public class GeoCoords
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public interface ILocationService
    {
        Task<GeoCoords> GetLocationAsync();
    }
}
