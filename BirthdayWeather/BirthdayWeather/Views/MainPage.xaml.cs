using System;
using Xamarin.Forms;
using BirthdayWeather.ViewModels;

namespace BirthdayWeather.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _vm => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}
