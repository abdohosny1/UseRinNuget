using Microsoft.AspNetCore.Mvc;
using UseRinINApi.Model;
using UseRinINApi.services;

namespace UseRinINApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherApiService _weatherApiService;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherApiService weatherApiService)
        {
            _logger = logger;
            _weatherApiService = weatherApiService;
        }

    
        [HttpGet("GetWeatherData")]
        public async Task<IActionResult> GetWeatherData([FromQuery] string cityName)
        {
            string apiKey = ""; // Replace with your actual OpenWeatherMap API key

            try
            {
                WeatherApiResponse result = await _weatherApiService.GetWeatherDataAsync(cityName, apiKey);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
