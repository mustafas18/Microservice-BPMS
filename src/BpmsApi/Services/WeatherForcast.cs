
namespace BpmsApi.Services
{
    public class WeatherForcast : IWeatherForcast
    {
        public List<string> Forcast15Days()
        {
            return new List<string>{"41,33","39,30","38,32","40,38"};
        }
    }
}
