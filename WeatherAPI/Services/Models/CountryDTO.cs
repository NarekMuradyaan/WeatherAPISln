//using static WeatherAPI.Services.Models.Country;

namespace WeatherAPI.Services.Models
{
    public class CountryDTO
    {
        public Name Name { get; set; }
        public bool independent { get; set; }
        public string region { get; set; }
        public List<string> borders { get; set; }
        public int population { get; set; }
    }
}
