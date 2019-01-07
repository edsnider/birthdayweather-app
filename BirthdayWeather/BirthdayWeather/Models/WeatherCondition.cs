using System;

namespace BirthdayWeather.Models
{
    public class WeatherCondition
    {
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public string Summary { get; set; }
        public string IconName { get; set; }
    }
}
