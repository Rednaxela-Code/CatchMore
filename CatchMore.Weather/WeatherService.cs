using CatchMore.Utility;

namespace CatchMore.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClient;

        public WeatherService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public void GetWeather(ApiSettings settings, double lat, double lon)
        {
            var client = _httpClient.CreateClient();
        }

        // Do i need a settings object? Settings are super simple as they are...
        public ApiSettings InitSettings()
        {
            ApiSettings settings = new ApiSettings();
            settings.ApiKey = Security.WeatherApiKey;
            settings.Url = new Uri("");
            return settings;
        }
    }
}
