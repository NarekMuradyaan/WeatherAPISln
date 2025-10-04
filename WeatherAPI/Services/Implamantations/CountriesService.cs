using System.Text.Json;
using WeatherAPI.Services.Interfaces;
using WeatherAPI.Services.Models;
using static System.Net.WebRequestMethods;

namespace WeatherAPI.Services.Implamantations
{
    public class CountriesService1 : ICountiesService
    {
        private HttpClient _httpClient;

        public string? BaseUrl { get; set; } = "https://restcountries.com/v3.1/name/";

        public CountriesService1(HttpClient http)
        {
            _httpClient = http;
        }

        public async Task<Country> GetCountryAsync(string country_name)
        {
            _httpClient.BaseAddress = new Uri(BaseUrl);
            var responseMesage = await _httpClient.GetAsync(country_name);
            responseMesage.EnsureSuccessStatusCode();
            var res = await responseMesage.Content.ReadAsStringAsync();
            var x = JsonSerializer.Deserialize<List<Country>>(res, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return x.FirstOrDefault();
        }


        //public async Task<CountryDTO> GetCountryDTOAsync()
        //{
        //    Country country = await GetCountryAsync();
        //}
    }
}
