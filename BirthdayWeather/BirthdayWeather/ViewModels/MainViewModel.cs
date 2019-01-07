using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BirthdayWeather.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
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

        public MainViewModel()
        {
            Birthday = DateTime.Today;
            GetWeatherCommand = new Command(async () => await GetWeather(), CanGetWeather);
        }

        async Task GetWeather()
        {
            // TODO
        }

        bool CanGetWeather() => Birthday.Date < DateTime.Today;
    }
}
