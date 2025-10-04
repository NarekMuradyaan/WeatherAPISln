using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAPI.Services.Interfaces;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountiesService _CountiesService;
        public CountriesController(ICountiesService countiesService)
        {
            _CountiesService = countiesService;
        }
        [HttpGet("{city}")]
        public async Task<IActionResult> Get(string city)
        {
            var res = await _CountiesService.GetCountryAsync(city);
            return Ok(res);
        }
    }
}
