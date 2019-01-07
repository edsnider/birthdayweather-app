using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using BirthdayWeather.Services;

[assembly: Dependency(typeof(LocationService))]
namespace BirthdayWeather.Services
{
    public class LocationService : ILocationService
    {
        public async Task<GeoCoords> GetLocationAsync()
        {
            try
            {
                var location = await Xamarin.Essentials.Geolocation.GetLocationAsync();

                return new GeoCoords
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
