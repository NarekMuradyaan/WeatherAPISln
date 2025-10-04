using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        [HttpGet("{country}")]
        public async Task<IActionResult> Get(string country)
        { 
            var baseUrl = "https://localhost:7159";
            var endpoint = $"api/Countries/{country}";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            var response = await httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return Ok(result);
        }
    }
}
