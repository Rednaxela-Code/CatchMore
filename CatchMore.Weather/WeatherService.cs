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

        public ApiSettings InitSettings()
        {
            ApiSettings settings = new ApiSettings();
            settings.ApiKey = Security.WeatherApiKey;
            settings.Url = new Uri("");
            return settings;
        }
    }
}
