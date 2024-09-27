using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [EnableRateLimiting("smallSmall")]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly IWeatherService weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IWeatherService weatherService)
        {
            this.logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            logger.LogInformation("Retreiving weather information.");

            var info = weatherService.GetWeatherInfo();
            logger.LogInformation($"WeatherForecasts: {info}");

            return info;
        }
    }
}
