using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using BirthdayWeather.Services;
using BirthdayWeather.Models;

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

        Forecast _currentForecast;
        public Forecast CurrentForecast
        {
            get => _currentForecast;
            set
            {
                _currentForecast = value;
                OnPropertyChanged();
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
            CurrentForecast = await _weatherService.GetWeatherAsync(location.Latitude, location.Longitude, Birthday);
        }

        bool CanGetWeather() => Birthday.Date < DateTime.Today;
    }
}
