//using WeatherAPI.Services.Models;
using WeatherAPI.Services.Models;

namespace WeatherAPI.Services.Interfaces
{
    public interface ICountiesService
    {
        Task<Country> GetCountryAsync(string n); 
    }
}
