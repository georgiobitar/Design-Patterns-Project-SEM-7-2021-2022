using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
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

        [HttpPost(Name = "GetWeatherForecast")]
        public LoginResponseDTO Post(LoginRequestDTO loginRequest)
        {
           var x = loginService.Login(new LoginRequestDTO() { UserName = loginRequest.UserName, Password = loginRequest.Password });
            return x;
        }
    }
}