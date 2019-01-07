using System;
using System.Linq;
using Newtonsoft.Json;
using BirthdayWeather.Models;

namespace BirthdayWeather.Services.ApiResponseModels.DarkSky
{
    // Partial representation of the Dark Sky API response (https://darksky.net/dev/docs#response-format)

    public class DarkSkyResponse
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("currently")]
        public Current Current { get; set; }

        [JsonProperty("hourly")]
        public Hourly Hourly { get; set; }

        [JsonProperty("daily")]
        public Daily Daily { get; set; }

        public static DarkSkyResponse FromJson(string json) => JsonConvert.DeserializeObject<DarkSkyResponse>(json);
    }

    public class Current : WeatherData
    {
    }

    public class Hourly : BaseData
    {
        [JsonProperty("data")]
        public WeatherData[] Data { get; set; }
    }

    public class Daily : BaseData
    {
        [JsonProperty("data")]
        public WeatherData[] Data { get; set; }
    }

    public class BaseData
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class WeatherData : BaseData
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("temperatureHigh")]
        public double TemperatureHigh { get; set; }

        [JsonProperty("temperatureLow")]
        public double TemperatureLow { get; set; }

        [JsonProperty("temperatureMin")]
        public double TemperatureMin { get; set; }

        [JsonProperty("temperatureMax")]
        public double TemperatureMax { get; set; }
    }

    public static class Extensions
    {
        public static Forecast ToForecastModel(this DarkSkyResponse model)
        {
            var forecast = new Forecast
            {
                Current = model.Current.ToWeatherConditionModel(),
                Hourly = model.Hourly.Data.Select(x => x.ToWeatherConditionModel())
            };

            return forecast;
        }

        public static WeatherCondition ToWeatherConditionModel(this WeatherData model)
        {
            var weather = new WeatherCondition
            {
                Time = EpochTimeToDateTime(model.Time),
                Temperature = model.Temperature,
                Summary = model.Summary,
                IconName = model.Icon
            };

            return weather;
        }

        public static DateTime EpochTimeToDateTime(long seconds)
        {
            return DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;
        }

        public static long ToEpochTime(this DateTime dateTime)
        {
            return new DateTimeOffset(dateTime.ToUniversalTime()).ToUnixTimeSeconds();
        }
    }
}
