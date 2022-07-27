using Microsoft.AspNetCore.Mvc;

namespace curso_api_net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast>  ListWeatherForeCast = new List<WeatherForecast>();
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if(ListWeatherForeCast == null || !ListWeatherForeCast.Any())
        {
            ListWeatherForeCast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),            
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/weatherForeCast")]
    [Route("Get/weatherForeCast2")]
    [Route("[action]")]
    public IEnumerable<WeatherForecast> Getw()
    {
        return ListWeatherForeCast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForeCast)
    {
        ListWeatherForeCast.Add(weatherForeCast);
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherForeCast.RemoveAt(index);
        return Ok();
    }
}
