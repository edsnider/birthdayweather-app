using System;
using Xamarin.Forms;
using BirthdayWeather.ViewModels;
using BirthdayWeather.Services;

namespace BirthdayWeather.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _vm => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(DependencyService.Get<ILocationService>(), DependencyService.Get<IWeatherService>());
        }

        void DarkSkyLinkClicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://darksky.net/poweredby/"));
        }
    }
}
