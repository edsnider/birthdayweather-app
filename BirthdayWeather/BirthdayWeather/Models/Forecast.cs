using System;
using System.Collections.Generic;

namespace BirthdayWeather.Models
{
    public class Forecast
    {
        public WeatherCondition Current { get; set; }
        public IEnumerable<WeatherCondition> Hourly { get; set; }
    }
}
