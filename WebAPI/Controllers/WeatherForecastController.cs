using Infrastructure.Model.DataContracts.Requests;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoginService loginService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoginService loginService)
        {
            _logger = logger;
            this.loginService = loginService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public bool Get()
        {
            return loginService.Login(new LoginRequestDTO() { UserName = "jounix", Password = "12345" }).Success;
        }
    }
}