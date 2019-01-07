using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using BirthdayWeather.Services;

namespace BirthdayWeather.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly ILocationService _locationService;
        readonly IWeatherService _weatherService;

        DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged();
                GetWeatherCommand?.ChangeCanExecute();
            }
        }

        public Command GetWeatherCommand { get; }

        public MainViewModel(ILocationService locationService, IWeatherService weatherService)
        {
            _locationService = locationService;
            _weatherService = weatherService;

            Birthday = DateTime.Today;
            GetWeatherCommand = new Command(async () => await GetWeather(), CanGetWeather);
        }

        async Task GetWeather()
        {
            var location = await _locationService.GetLocationAsync();
            var forecast = await _weatherService.GetWeatherAsync(location.Latitude, location.Longitude, Birthday);
        }

        bool CanGetWeather() => Birthday.Date < DateTime.Today;
    }
}
