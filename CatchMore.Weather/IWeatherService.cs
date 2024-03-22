namespace CatchMore.Weather
{
    public interface IWeatherService
    {
        public ApiSettings InitSettings();
        public void GetWeather(ApiSettings settings, double lat, double lon);
    }
}
